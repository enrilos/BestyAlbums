namespace BestyAlbums.Services
{
    using BestyAlbums.Models.ViewModels.Albums;
    using Contracts;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Models.InputModels.Albums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumService : IAlbumService
    {
        private readonly BestyAlbumsDbContext context;

        public AlbumService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public void Add(string name, DateTime released, Genre genre, string coverUrl, decimal price, AlbumStatus albumStatus, string artist, StudioType studioType, string label, int? productionTimeInDays)
        {
            var foundArtist = this.context.Artists.FirstOrDefault(x => x.Name == artist);

            if (foundArtist == null)
            {
                throw new ArgumentNullException("Artist name was not found.");
            }

            var album = new Album
            {
                Name = name,
                Released = released,
                Genre = genre,
                CoverUrl = coverUrl,
                Price = price,
                AlbumStatus = albumStatus,
                Artist = foundArtist,
                StudioType = studioType,
                Label = label,
                ProductionTimeInDays = productionTimeInDays
            };

            this.context.Albums.Add(album);
            this.context.SaveChanges();
        }

        public void Edit(AlbumEditModel model)
        {
            var album = this.context.Albums.Find(model.Id);

            album.Name = model.Name;
            album.CoverUrl = model.CoverUrl;
            album.Price = model.Price;
            album.AlbumStatus = model.AlbumStatus;

            this.context.SaveChanges();
        }

        public bool Exists(string name)
        {
            if (this.context.Albums.FirstOrDefault(x => x.Name == name) == null)
            {
                return false;
            }

            return true;
        }

        public bool Exists(int id)
        {
            if (this.context.Albums.FirstOrDefault(x => x.Id == id) == null)
            {
                return false;
            }

            return true;
        }

        public Album Get(int id)
        {
            return this.context.Albums.Include(x => x.Artist).FirstOrDefault(x => x.Id == id);
        }

        public IList<string> GetAllAlbumNames()
        {
            return this.context.Albums.Select(x => x.Name).ToList();
        }

        public IList<AlbumAllViewModel> GetAllAlbums()
        {
            return this.context.Albums
                .Select(x => new AlbumAllViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    AlbumStatus = x.AlbumStatus,
                    CoverUrl = x.CoverUrl,
                    SongsCount = x.Songs.Count,
                    Price = x.Price
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var album = this.context.Albums.FirstOrDefault(x => x.Id == id);
            this.context.Albums.Remove(album);
            this.context.SaveChanges();
        }

        public AlbumSongsViewModel GetAlbumSongs(int id)
        {
            var album = this.context.Albums
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                .FirstOrDefault(x => x.Id == id);

            var albumModel = new AlbumSongsViewModel
            {
                Name = album.Name,
                Released = album.Released,
                CoverUrl = album.CoverUrl,
                Genre = album.Genre,
                AlbumStatus = album.AlbumStatus,
                Artist = album.Artist.Name,
                Label = album.Label,
                Price = album.Price,
                ProductionTimeInDays = album.ProductionTimeInDays,
                Songs = album.Songs.Select(x => x.Name).ToList(),
                StudioType = album.StudioType
            };

            return albumModel;
        }

        public IList<AlbumsHomeViewModel> GetTopThreeLatestAlbums()
        {
            var albums = this.context.Albums
                .OrderByDescending(x => x.CreatedOn)
                .Take(3)
                .Select(x => new AlbumsHomeViewModel
                {
                    Name = x.Name,
                    CoverUrl = x.CoverUrl,
                    Artist = x.Artist.Name
                })
                .ToList();

            return albums;
        }
    }
}

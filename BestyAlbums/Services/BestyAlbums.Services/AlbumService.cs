namespace BestyAlbums.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Models.InputModels.Albums;
    using Models.ViewModels.Albums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumService : IAlbumService
    {
        private readonly BestyAlbumsDbContext data;

        public AlbumService(BestyAlbumsDbContext data)
            => this.data = data;

        public int Add(
            string name,
            DateTime released,
            Genre genre,
            string coverUrl,
            decimal price,
            AlbumStatus albumStatus,
            string artist,
            StudioType studioType,
            string label,
            int? productionTimeInDays)
        {
            var foundArtist = data.Artists.FirstOrDefault(x => x.Name == artist);

            if (foundArtist == null)
            {
                return 0;
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

            data.Albums.Add(album);
            data.SaveChanges();

            return album.Id;
        }

        public bool Edit(
            int id,
            string name,
            string coverUrl,
            decimal price,
            AlbumStatus albumStatus)
        {
            var album = data.Albums.Find(id);

            if (album == null)
            {
                return false;
            }

            album.Name = name;
            album.CoverUrl = coverUrl;
            album.Price = price;
            album.AlbumStatus = albumStatus;

            data.SaveChanges();

            return true;
        }

        public bool Exists(string name)
            => data.Albums
            .Any(x => x.Name == name);

        public bool Exists(int id)
            => data.Albums
            .Any(x => x.Id == id);

        public EditAlbumFormModel GetEditModel(int id)
        {
            var album = data
                .Albums
                .FirstOrDefault(x => x.Id == id);

            return new EditAlbumFormModel
            {
                Id = album.Id,
                Name = album.Name,
                Price = album.Price,
                CoverUrl = album.CoverUrl,
                AlbumStatus = album.AlbumStatus
            };
        }

        public IEnumerable<string> GetNames()
            => data.Albums
            .Select(x => x.Name)
            .ToList();

        public IEnumerable<AlbumListingViewModel> GetAll()
            => data.Albums
                .Select(x => new AlbumListingViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    AlbumStatus = x.AlbumStatus,
                    CoverUrl = x.CoverUrl,
                    SongCount = x.Songs.Count,
                    Price = x.Price
                })
                .ToList();

        public void Delete(int id)
        {
            var album = data.Albums.FirstOrDefault(x => x.Id == id);
            data.Albums.Remove(album);
            data.SaveChanges();
        }

        public AlbumSongListingViewModel GetSongs(int id)
        {
            var album = data.Albums
                .Where(x => x.Id == id)
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                .FirstOrDefault();

            var albumModel = new AlbumSongListingViewModel
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
                SongNames = album.Songs.Select(x => x.Name).ToList(),
                StudioType = album.StudioType
            };

            return albumModel;
        }

        public IEnumerable<AlbumListingHomeViewModel> GetLatestThree()
            => data.Albums
                .OrderByDescending(x => x.CreatedOn)
                .Take(3)
                .Select(x => new AlbumListingHomeViewModel
                {
                    Name = x.Name,
                    CoverUrl = x.CoverUrl,
                    Artist = x.Artist.Name
                })
                .ToList();
    }
}
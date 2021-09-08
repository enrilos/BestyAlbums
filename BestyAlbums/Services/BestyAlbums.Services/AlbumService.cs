namespace BestyAlbums.Services
{
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

        public int Add(string name, DateTime released, Genre genre, string coverUrl, decimal price, AlbumStatus albumStatus, string artist, StudioType studioType, string label, int? productionTimeInDays)
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

            return album.Id;
        }

        public void Edit(AlbumEditModel model)
        {
            var album = this.context.Albums.Find(model.Id);

            album.Name = model.Name;
            album.AlbumStatus = model.AlbumStatus;
            album.CoverUrl = model.CoverUrl;
            album.Price = model.Price;

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

        public IList<Album> GetAllAlbums()
        {
            return this.context.Albums.ToList();
        }
    }
}

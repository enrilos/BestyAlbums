namespace BestyAlbums.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
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

            if(foundArtist == null)
            {
                throw new ArgumentNullException("Artist name was not found.");
            }

            var album = new Album
            {
                Name = name,
                Released = released,
                Genre = genre,
                CoverURL= coverUrl,
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

        public bool Exists(string name)
        {
            return this.context.Albums.FirstOrDefault(x => x.Name == name) != null;
        }

        public IList<string> GetAllAlbums()
        {
            return this.context.Albums
                .ToList()
                .Select(x => x.Name)
                .ToList();
        }
    }
}

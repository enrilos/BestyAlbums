namespace BestyAlbums.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using System;

    public class ArtistService : IArtistService
    {
        private readonly BestyAlbumsDbContext context;

        public ArtistService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public int Add(string name, DateTime founded, string location, double rating)
        {
            var artist = new Artist
            {
                Name = name,
                Founded = founded,
                Location = location,
                Rating = rating
            };

            this.context.Artists.Add(artist);
            this.context.SaveChanges();

            return artist.Id;
        }
    }
}

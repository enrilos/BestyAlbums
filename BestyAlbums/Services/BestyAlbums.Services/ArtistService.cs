namespace BestyAlbums.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using System;
    using System.Linq;

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

        public bool Exists(string name)
        {
            if(this.context.Artists.FirstOrDefault(x => x.Name == name) == null)
            {
                return false;
            }

            return true;
        }

        public string[] GetAllArtistsNames()
        {
            return this.context.Artists
                .ToList()
                .Select(x => x.Name)
                .ToArray();
        }
    }
}

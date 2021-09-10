namespace BestyAlbums.Services
{
    using BestyAlbums.Models.ViewModels.Artists;
    using Contracts;
    using Data;
    using Data.Models;
    using Models.InputModels.Artists;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArtistService : IArtistService
    {
        private readonly BestyAlbumsDbContext context;

        public ArtistService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public int Add(string name, DateTime founded, string location, double rating, string imageUrl)
        {
            var artist = new Artist
            {
                Name = name,
                Founded = founded,
                Location = location,
                Rating = rating,
                ImageUrl = imageUrl
            };

            this.context.Artists.Add(artist);
            this.context.SaveChanges();

            return artist.Id;
        }

        public bool Exists(int id)
        {
            if (this.context.Artists.FirstOrDefault(x => x.Id == id) == null)
            {
                return false;
            }

            return true;
        }

        public bool Exists(string name)
        {
            if (this.context.Artists.FirstOrDefault(x => x.Name == name) == null)
            {
                return false;
            }

            return true;
        }

        public Artist GetArtistByName(string name)
        {
            return this.context.Artists.FirstOrDefault(x => x.Name == name);
        }

        public IList<string> GetAllNames()
        {
            return this.context
                .Artists
                .ToList()
                .Select(x => x.Name)
                .ToList();
        }

        public IList<ArtistAllViewModel> GetAll()
        {
            return this.context.Artists
                .Select(x => new ArtistAllViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Founded = x.Founded,
                    Rating = x.Rating,
                    ImageUrl = x.ImageUrl,
                    Location = x.Location
                })
                .ToList();
        }

        public Artist GetArtistById(int id)
        {
            return this.context.Artists.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(ArtistEditModel model)
        {
            var artist = this.context.Artists.Find(model.Id);

            artist.Name = model.Name;
            artist.Founded = model.Founded;
            artist.Location = model.Location;
            artist.Rating = model.Rating;
            artist.ImageUrl = model.ImageUrl;

            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var artist = this.context.Artists.FirstOrDefault(x => x.Id == id);
            this.context.Artists.Remove(artist);
            this.context.SaveChanges();
        }
    }
}

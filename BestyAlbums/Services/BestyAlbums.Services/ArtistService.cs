namespace BestyAlbums.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using Models.InputModels.Artists;
    using Models.ViewModels.Artists;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ArtistService : IArtistService
    {
        private readonly BestyAlbumsDbContext data;

        public ArtistService(BestyAlbumsDbContext data)
            => this.data = data;

        public int Add(
            string name,
            DateTime founded,
            string location,
            double rating,
            string imageUrl)
        {
            var artist = new Artist
            {
                Name = name,
                Founded = founded,
                Location = location,
                Rating = rating,
                ImageUrl = imageUrl
            };

            data.Artists.Add(artist);
            data.SaveChanges();

            return artist.Id;
        }

        public bool Exists(int id)
            => data.Artists
            .Any(x => x.Id == id);

        public bool Exists(string name)
            => data.Artists
            .Any(x => x.Name == name);

        public int GetIdByName(string name)
            => data.Artists
            .FirstOrDefault(x => x.Name == name).Id;

        public IEnumerable<string> GetNames()
            => data.Artists
            .Select(x => x.Name)
            .ToList();

        public IEnumerable<ArtistListingViewModel> GetAll()
            => data.Artists
                .Select(x => new ArtistListingViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Founded = x.Founded,
                    Rating = x.Rating,
                    ImageUrl = x.ImageUrl,
                    Location = x.Location
                })
                .ToList();

        public EditArtistFormModel GetEditModel(int id)
        {
            var artist = data.Artists.Find(id);

            if (artist == null)
            {
                return null;
            }

            return new EditArtistFormModel
            {
                Name = artist.Name,
                Founded = artist.Founded,
                Location = artist.Location,
                Rating = artist.Rating,
                ImageUrl = artist.ImageUrl
            };
        }

        public void Edit(
            int id,
            string name,
            DateTime founded,
            string location,
            double rating,
            string imageUrl)
        {
            var artist = data.Artists.Find(id);

            artist.Name = name;
            artist.Founded = founded;
            artist.Location = location;
            artist.Rating = rating;
            artist.ImageUrl = imageUrl;

            data.SaveChanges();
        }

        public void Delete(int id)
        {
            var artist = data.Artists.FirstOrDefault(x => x.Id == id);

            data.Artists.Remove(artist);
            data.SaveChanges();
        }
    }
}
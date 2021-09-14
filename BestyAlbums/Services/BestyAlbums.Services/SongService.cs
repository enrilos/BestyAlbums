namespace BestyAlbums.Services.Contracts
{
    using BestyAlbums.Models.InputModels.Songs;
    using BestyAlbums.Models.ViewModels.Songs;
    using Data;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SongService : ISongService
    {
        private readonly BestyAlbumsDbContext context;

        public SongService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public void Add(string name, string album)
        {
            var foundAlbum = this.context.Albums.FirstOrDefault(x => x.Name == album);

            if (foundAlbum == null)
            {
                throw new ArgumentNullException("Album name was not found.");
            }
            if (foundAlbum.Songs.Any(x => x.Name == name && album == foundAlbum.Name))
            {
                throw new InvalidOperationException("Song in with that name is already present in the album.");
            }

            var song = new Song
            {
                Name = name,
                Album = foundAlbum
            };

            this.context.Songs.Add(song);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var song = this.context.Songs.FirstOrDefault(x => x.Id == id);
            this.context.Songs.Remove(song);
            this.context.SaveChanges();
        }

        public void Edit(SongEditModel model)
        {
            var song = this.context.Songs.Find(model.Id);
            song.Name = model.Name;
            this.context.SaveChanges();
        }

        public bool Exists(int id)
        {
            if (this.context.Songs.FirstOrDefault(x => x.Id == id) == null)
            {
                return false;
            }

            return true;
        }

        public Song Get(int id)
        {
            return this.context.Songs.FirstOrDefault(x => x.Id == id);
        }

        public IList<SongAllViewModel> GetAll()
        {
            return this.context.Songs
                .Select(x => new SongAllViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Album = x.Album.Name,
                })
                .ToList();
        }
    }
}

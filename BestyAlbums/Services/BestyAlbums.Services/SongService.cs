namespace BestyAlbums.Services.Contracts
{
    using Data;
    using Data.Models;
    using Models.InputModels.Songs;
    using Models.ViewModels.Songs;
    using System.Collections.Generic;
    using System.Linq;

    public class SongService : ISongService
    {
        private readonly BestyAlbumsDbContext data;

        public SongService(BestyAlbumsDbContext data)
            => this.data = data;

        public bool Add(string name, string album)
        {
            var foundAlbum = data.Albums.FirstOrDefault(x => x.Name == album);

            if (foundAlbum == null
                || foundAlbum.Songs.Any(x => x.Name == name && album == foundAlbum.Name))
            {
                return false;
            }

            var song = new Song
            {
                Name = name,
                Album = foundAlbum
            };

            data.Songs.Add(song);
            data.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            var song = data.Songs.FirstOrDefault(x => x.Id == id);

            data.Songs.Remove(song);
            data.SaveChanges();
        }

        public bool Edit(
            int id,
            string name)
        {
            var song = data.Songs.Find(id);

            if (song == null)
            {
                return false;
            }

            song.Name = name;

            data.SaveChanges();

            return true;
        }

        public bool Exists(int id)
            => data.Songs
            .Any(x => x.Id == id);

        public EditSongFormModel GetEditModel(int id)
        {
            var song = data
                .Songs
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return new EditSongFormModel
            {
                Id = song.Id,
                Name = song.Name
            };
        }

        public IEnumerable<SongListingViewModel> GetAll()
            => data.Songs
                .Select(x => new SongListingViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Album = x.Album.Name,
                })
                .ToList();
    }
}
namespace BestyAlbums.Services.Contracts
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class SongService : ISongService
    {
        private readonly BestyAlbumsDbContext context;

        public SongService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public int Add(string name, string album)
        {
            var foundAlbum = this.context.Albums
                .Include(x => x.Songs)
                .ToList()
                .FirstOrDefault(x => x.Name == album);

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

            return song.Id;
        }
    }
}

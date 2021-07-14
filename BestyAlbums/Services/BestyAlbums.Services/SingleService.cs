namespace BestyAlbums.Services
{
    using Contracts;
    using Data;
    using Data.Models.Enums;
    using System;
    using System.Linq;

    public class SingleService : ISingleService
    {
        private readonly BestyAlbumsDbContext context;

        public SingleService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public int Add(string name, Genre genre, string artist, StudioType studioType, DateTime released, int? productionTimeInDays)
        {
            var foundArtist = this.context.Artists.FirstOrDefault(x => x.Name == artist);
            
            if(foundArtist == null)
            {
                throw new ArgumentNullException("Artist with provided name was not found.");
            }

            var single = new Data.Models.Single()
            {
                Name = name,
                Genre = genre,
                Artist = foundArtist,
                StudioType = studioType,
                Released = released,
                ProductionTimeInDays = productionTimeInDays
            };

            this.context.Singles.Add(single);
            this.context.SaveChanges();

            return single.Id;
        }
    }
}
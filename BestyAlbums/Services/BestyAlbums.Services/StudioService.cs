namespace BestyAlbums.Services
{
    using BestyAlbums.Data;
    using BestyAlbums.Data.Models;
    using Contracts;
    using Data.Models.Enums;
    using System;

    public class StudioService : IStudioService
    {
        private readonly BestyAlbumsDbContext context;

        public StudioService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public int Add(StudioType studioType, DateTime founded, DateTime? discontinued, string headquarters, string websiteUrl)
        {
            var studio = new Studio
            {
                StudioType = studioType,
                Founded = founded,
                Discontinued = discontinued,
                Headquarters = headquarters,
                WebsiteURL = websiteUrl
            };

            this.context.Studios.Add(studio);
            this.context.SaveChanges();

            return studio.Id;
        }
    }
}

namespace BestyAlbums.Services.Contracts
{
    using Data.Models.Enums;
    using System;

    public interface IStudioService
    {
        int Add(StudioType studioType, DateTime founded, DateTime? discontinued, string headquarters, string websiteUrl);
    }
}

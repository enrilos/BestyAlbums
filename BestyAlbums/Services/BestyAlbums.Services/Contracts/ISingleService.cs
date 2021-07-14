namespace BestyAlbums.Services.Contracts
{
    using Data.Models.Enums;
    using System;

    public interface ISingleService
    {
        int Add(string name, Genre genre, string artist, StudioType studioType, DateTime released, int? productionTimeInDays);
    }
}
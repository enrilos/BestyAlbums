namespace BestyAlbums.Services.Contracts
{
    using Data.Models.Enums;
    using System;

    public interface IAlbumService
    {
        int Add(string name, DateTime released, Genre genre, string coverUrl, decimal price, AlbumStatus albumStatus, string artist, StudioType studioType, string label, int? productionTimeInDays);
    }
}
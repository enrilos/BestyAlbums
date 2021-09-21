namespace BestyAlbums.Services.Contracts
{
    using BestyAlbums.Models.ViewModels.Albums;
    using Data.Models;
    using Data.Models.Enums;
    using Models.InputModels.Albums;
    using System;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        void Add(string name, DateTime released, Genre genre, string coverUrl, decimal price, AlbumStatus albumStatus, string artist, StudioType studioType, string label, int? productionTimeInDays);

        bool Exists(int id);

        bool Exists(string name);

        void Edit(AlbumEditModel model);

        void Delete(int id);

        Album Get(int id);

        IList<string> GetAllAlbumNames();

        IList<AlbumAllViewModel> GetAllAlbums();

        AlbumSongsViewModel GetAlbumSongs(int id);
    }
}
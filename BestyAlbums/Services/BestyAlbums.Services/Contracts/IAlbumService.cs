﻿namespace BestyAlbums.Services.Contracts
{
    using Data.Models;
    using Data.Models.Enums;
    using Models.InputModels.Albums;
    using System;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        int Add(string name, DateTime released, Genre genre, string coverUrl, decimal price, AlbumStatus albumStatus, string artist, StudioType studioType, string label, int? productionTimeInDays);

        bool Exists(int id);

        bool Exists(string name);

        void Edit(AlbumEditModel model);

        Album Get(int id);

        IList<string> GetAllAlbumNames();

        IList<Album> GetAllAlbums();
    }
}
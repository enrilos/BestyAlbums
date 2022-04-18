namespace BestyAlbums.Services.Contracts
{
    using Data.Models.Enums;
    using Models.InputModels.Albums;
    using Models.ViewModels.Albums;
    using System;
    using System.Collections.Generic;

    public interface IAlbumService
    {
        int Add(
            string name,
            DateTime released,
            Genre genre,
            string coverUrl,
            decimal price,
            AlbumStatus albumStatus,
            string artist,
            StudioType studioType,
            string label,
            int? productionTimeInDays);

        bool Exists(int id);

        bool Exists(string name);

        bool Edit(
            int id,
            string name,
            string coverUrl,
            decimal price,
            AlbumStatus albumStatus);

        void Delete(int id);

        EditAlbumFormModel GetEditModel(int id);

        IEnumerable<AlbumListingHomeViewModel> GetLatestThree();

        IEnumerable<string> GetNames();

        IEnumerable<AlbumListingViewModel> GetAll();

        AlbumSongListingViewModel GetSongs(int id);
    }
}
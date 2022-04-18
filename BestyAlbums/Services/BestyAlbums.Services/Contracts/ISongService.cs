namespace BestyAlbums.Services.Contracts
{
    using Models.InputModels.Songs;
    using Models.ViewModels.Songs;
    using System.Collections.Generic;

    public interface ISongService
    {
        bool Add(
            string name,
            string album);

        bool Exists(int id);

        void Delete(int id);

        bool Edit(
            int id,
            string name);

        EditSongFormModel GetEditModel(int id);

        IEnumerable<SongListingViewModel> GetAll();
    }
}
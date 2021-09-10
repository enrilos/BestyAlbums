namespace BestyAlbums.Services.Contracts
{
    using BestyAlbums.Models.ViewModels.Songs;
    using Data.Models;
    using System.Collections.Generic;

    public interface ISongService
    {
        int Add(string name, string album);

        bool Exists(int id);

        Song Get(int id);

        IList<SongAllViewModel> GetAll();
    }
}

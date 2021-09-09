namespace BestyAlbums.Services.Contracts
{
    using BestyAlbums.Models.ViewModels.Albums;
    using System.Collections.Generic;

    public interface ISongService
    {
        int Add(string name, string album);
    }
}

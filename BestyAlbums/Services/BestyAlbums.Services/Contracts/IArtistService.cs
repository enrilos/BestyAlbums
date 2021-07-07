namespace BestyAlbums.Services.Contracts
{
    using Data.Models;
    using System;
    using System.Collections.Generic;

    public interface IArtistService
    {
        int Add(string name, DateTime founded, string location, double rating);

        bool Exists(string name);

        Artist GetArtistByName(string name);

        IList<string> GetAllNames();
    }
}

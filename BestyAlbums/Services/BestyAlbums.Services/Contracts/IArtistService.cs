namespace BestyAlbums.Services.Contracts
{
    using Data.Models;
    using Models.InputModels.Artists;
    using System;
    using System.Collections.Generic;

    public interface IArtistService
    {
        int Add(string name, DateTime founded, string location, double rating, string imageUrl);

        bool Exists(int id);

        bool Exists(string name);

        void Edit(ArtistEditModel model);

        Artist GetArtistByName(string name);

        Artist GetArtistById(int id);

        IList<string> GetAllNames();

        IList<Artist> GetAll();
    }
}

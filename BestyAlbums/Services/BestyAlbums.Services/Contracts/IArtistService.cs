namespace BestyAlbums.Services.Contracts
{
    using Models.InputModels.Artists;
    using Models.ViewModels.Artists;
    using System;
    using System.Collections.Generic;

    public interface IArtistService
    {
        int Add(
            string name,
            DateTime founded,
            string location,
            double rating,
            string imageUrl);

        bool Exists(int id);

        bool Exists(string name);

        void Edit(
            int id,
            string name,
            DateTime founded,
            string location,
            double rating,
            string imageUrl);

        void Delete(int id);

        int GetIdByName(string name);

        EditArtistFormModel GetEditModel(int id);

        IEnumerable<string> GetNames();

        IEnumerable<ArtistListingViewModel> GetAll();
    }
}
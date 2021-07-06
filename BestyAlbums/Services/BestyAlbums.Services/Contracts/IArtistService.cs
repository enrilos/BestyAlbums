namespace BestyAlbums.Services.Contracts
{
    using System;

    public interface IArtistService
    {
        int Add(string name, DateTime founded, string location, double rating);

        bool Exists(string name);

        string[] GetAllArtistsNames();
    }
}

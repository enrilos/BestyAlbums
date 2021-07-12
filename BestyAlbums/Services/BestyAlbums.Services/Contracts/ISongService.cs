namespace BestyAlbums.Services.Contracts
{
    using System;

    public interface ISongService
    {
        int Add(string name, TimeSpan length, string album);
    }
}

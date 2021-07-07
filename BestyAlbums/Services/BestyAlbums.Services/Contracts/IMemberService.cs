namespace BestyAlbums.Services.Contracts
{
    using Data.Models;
    using Data.Models.Enums;
    using System;

    public interface IMemberService
    {
        int Add(string firstName, string lastName, DateTime birthdate, DateTime joined, DateTime? left, Gender gender, string imageUrl, Artist artist);
    }
}

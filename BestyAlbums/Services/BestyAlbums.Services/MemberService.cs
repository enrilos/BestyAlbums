namespace BestyAlbums.Services
{
    using Data.Models.Enums;
    using Contracts;
    using System;

    public class MemberService : IMemberService
    {
        public int Add(string firstName, string lastName, DateTime birthdate, DateTime joined, DateTime left, DateTime died, Gender gender, string imageUrl)
        {
            return 1;
        }
    }
}

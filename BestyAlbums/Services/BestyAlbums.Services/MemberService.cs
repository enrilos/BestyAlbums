namespace BestyAlbums.Services
{
    using Data.Models.Enums;
    using Contracts;
    using System;
    using Data.Models;
    using Data;

    public class MemberService : IMemberService
    {
        private readonly BestyAlbumsDbContext context;

        public MemberService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public int Add(string firstName, string lastName, DateTime birthdate, DateTime joined, DateTime? left, Gender gender, string imageUrl)
        {
            var member = new Member
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthdate,
                Joined = joined,
                Left = left,
                Gender = gender,
                ImageURL = imageUrl
            };

            this.context.Members.Add(member);
            this.context.SaveChanges();

            return member.Id;
        }
    }
}

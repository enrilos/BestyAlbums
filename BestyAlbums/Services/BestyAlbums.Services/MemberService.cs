namespace BestyAlbums.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MemberService : IMemberService
    {
        private readonly BestyAlbumsDbContext context;

        public MemberService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }

        public int Add(string firstName, string lastName, DateTime birthdate, DateTime joined, DateTime? left, Gender gender, string imageUrl, Artist artist)
        {
            var member = new Member
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthdate,
                Joined = joined,
                Left = left,
                Gender = gender,
                ImageURL = imageUrl,
                Artist = artist
            };

            this.context.Members.Add(member);
            this.context.SaveChanges();

            return member.Id;
        }

        public Member Get(int id)
        {
            return this.context.Members.Include(x => x.Artist).FirstOrDefault(x => x.Id == id);
        }

        public IList<Member> GetAll()
        {
            return this.context.Members
                .Include(x => x.Artist)
                .ToList()
                .Select(x => new Member()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    Joined = x.Joined,
                    Left = x.Left,
                    Gender = x.Gender,
                    ImageURL = x.ImageURL,
                    Artist = x.Artist
                })
                .ToList();
        }
    }
}

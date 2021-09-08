namespace BestyAlbums.Services
{
    using Models.InputModels.Members;
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
                ImageUrl = imageUrl,
                Artist = artist
            };

            this.context.Members.Add(member);
            this.context.SaveChanges();

            return member.Id;
        }

        public void Edit(MemberEditModel model)
        {
            var member = this.context.Members.Find(model.Id);

            member.FirstName = model.FirstName;
            member.LastName = model.LastName;
            member.BirthDate = model.BirthDate;
            member.Joined = model.Joined;
            member.Left = model.Left;
            member.Gender = model.Gender;
            member.ImageUrl = model.ImageUrl;

            this.context.SaveChanges();
        }

        public bool Exists(int id)
        {
            if (this.context.Members.FirstOrDefault(x => x.Id == id) == null)
            {
                return false;
            }

            return true;
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
                    ImageUrl = x.ImageUrl,
                    Artist = x.Artist
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var member = this.context.Members.FirstOrDefault(x => x.Id == id);
            this.context.Members.Remove(member);
            this.context.SaveChanges();
        }
    }
}

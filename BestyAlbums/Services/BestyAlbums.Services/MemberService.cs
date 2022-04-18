namespace BestyAlbums.Services
{
    using Contracts;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Models.InputModels.Members;
    using Models.ViewModels.Members;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MemberService : IMemberService
    {
        private readonly BestyAlbumsDbContext data;

        public MemberService(BestyAlbumsDbContext data)
            => this.data = data;

        public int Add(
            string firstName,
            string lastName,
            DateTime birthdate,
            DateTime joined,
            DateTime? left,
            Gender gender,
            string imageUrl,
            int artistId)
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
                ArtistId = artistId
            };

            data.Members.Add(member);
            data.SaveChanges();

            return member.Id;
        }

        public void Edit(
            int id,
            string firstName,
            string lastName,
            DateTime birthDate,
            DateTime joined,
            DateTime? left,
            Gender gender,
            string imageUrl)
        {
            var member = data.Members.Find(id);

            member.FirstName = firstName;
            member.LastName = lastName;
            member.BirthDate = birthDate;
            member.Joined = joined;
            member.Left = left;
            member.Gender = gender;
            member.ImageUrl = imageUrl;

            data.SaveChanges();
        }

        public bool Exists(int id)
            => data.Members
            .Any(x => x.Id == id);

        public EditMemberFormModel GetEditModel(int id)
        {
            var member = data.Members
                .Where(x => x.Id == id)
                .Include(x => x.Artist)
                .FirstOrDefault();

            return new EditMemberFormModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                BirthDate = member.BirthDate,
                Joined = member.Joined,
                Left = member.Left,
                Gender = member.Gender,
                ImageUrl = member.ImageUrl,
            };
        }

        public IEnumerable<MemberListingViewModel> GetAll()
        {
            return data.Members
                .Select(x => new MemberListingViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate.ToShortDateString(),
                    Joined = x.Joined.ToShortDateString(),
                    Left = x.Left == null ? null : x.Left.ToString(),
                    Gender = x.Gender,
                    ImageUrl = x.ImageUrl,
                    Artist = x.Artist.Name
                })
                .ToList();
        }

        public void Delete(int id)
        {
            var member = data.Members.FirstOrDefault(x => x.Id == id);

            data.Members.Remove(member);
            data.SaveChanges();
        }
    }
}
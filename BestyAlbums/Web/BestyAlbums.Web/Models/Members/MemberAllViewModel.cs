namespace BestyAlbums.Web.Models.Members
{
    using Data.Models.Enums;
    using System;

    public class MemberAllViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime Joined { get; set; }

        public DateTime? Left { get; set; }

        public Gender Gender { get; set; }

        public string ImageURL { get; set; }

        public string Artist { get; set; }
    }
}

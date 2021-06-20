namespace BestyAlbums.Data.Models
{
    using Enums;
    using System;

    public class Member
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime Joined { get; set; }

        public DateTime? Left { get; set; }

        public DateTime? Died { get; set; }

        public Gender Gender { get; set; }

        public string ImageURL { get; set; }

        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
    }
}

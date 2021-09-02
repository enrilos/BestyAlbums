namespace BestyAlbums.Data.Models
{
    using Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime Joined { get; set; }

        public DateTime? Left { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(maximumLength: 1024, MinimumLength = 10)]
        public string ImageUrl { get; set; }

        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
    }
}

namespace BestyAlbums.Web.Models
{
    using Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MemberInputModel
    {
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

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 10)]
        public string Artist { get; set; }
    }
}

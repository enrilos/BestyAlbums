namespace BestyAlbums.Web.Models
{
    using Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SingleInputModel
    {
        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Artist { get; set; }

        [EnumDataType(typeof(StudioType))]
        public StudioType StudioType { get; set; }

        public DateTime Released { get; set; }

        public int? ProductionTimeInDays { get; set; }
    }
}
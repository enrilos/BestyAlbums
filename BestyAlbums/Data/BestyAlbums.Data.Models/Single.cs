namespace BestyAlbums.Data.Models
{
    using Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Single
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

        [EnumDataType(typeof(StudioType))]
        public StudioType StudioType { get; set; }

        public DateTime Released { get; set; }

        public int? ProductionTimeInDays { get; set; }
    }
}

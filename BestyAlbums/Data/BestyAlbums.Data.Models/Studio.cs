namespace BestyAlbums.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Studio
    {
        [Key]
        public int Id { get; set; }

        [EnumDataType(typeof(StudioType))]
        public StudioType StudioType { get; set; }

        public DateTime Founded { get; set; }

        public DateTime? Discontinued { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Headquarters { get; set; }

        [Required]
        [StringLength(maximumLength: 256, MinimumLength = 10)]
        public string WebsiteURL { get; set; }

        public List<Album> RecordedAlbums { get; set; } = new List<Album>();

        public List<Single> RecordedSingles { get; set; } = new List<Single>();
    }
}

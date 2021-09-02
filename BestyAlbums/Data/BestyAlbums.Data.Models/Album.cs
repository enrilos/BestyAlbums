namespace BestyAlbums.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime Released { get; set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }
        
        [Required]
        [StringLength(maximumLength: 256, MinimumLength = 10)]
        public string CoverUrl { get; set; }

        [Range(typeof(double), "0", "9999.99")]
        public decimal Price { get; set; }

        [EnumDataType(typeof(AlbumStatus))]
        public AlbumStatus AlbumStatus { get; set; }

        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

        public StudioType StudioType { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Label { get; set; }

        public int? ProductionTimeInDays { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}

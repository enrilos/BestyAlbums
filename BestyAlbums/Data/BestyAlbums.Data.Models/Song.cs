namespace BestyAlbums.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }

        public TimeSpan Length { get; set; }

        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}

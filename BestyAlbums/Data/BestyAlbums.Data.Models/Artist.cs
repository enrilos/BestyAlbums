namespace BestyAlbums.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        [Key]
        public int Id { get; set; }

        public DateTime Founded { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Location { get; set; }

        public double Rating { get; set; }

        public List<Member> Members { get; set; } = new List<Member>();

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Song> Songs { get; set; } = new List<Song>();

        public List<Single> Singles { get; set; } = new List<Single>();
    }
}

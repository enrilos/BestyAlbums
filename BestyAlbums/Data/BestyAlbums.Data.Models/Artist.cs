namespace BestyAlbums.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime Founded { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Location { get; set; }

        public double Rating { get; set; }

        public string ImageUrl { get; set; }

        public List<Member> Members { get; set; } = new List<Member>();

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Single> Singles { get; set; } = new List<Single>();
    }
}

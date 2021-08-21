namespace BestyAlbums.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArtistAllViewModel
    {
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
    }
}

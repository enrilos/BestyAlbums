namespace BestyAlbums.Models.InputModels.Artists
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArtistEditModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime Founded { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Location { get; set; }

        [Range(typeof(double), "0.00", "5.00")]
        public double Rating { get; set; }

        [Required]
        [StringLength(maximumLength: 1024, MinimumLength = 2)]
        public string ImageUrl { get; set; }
    }
}

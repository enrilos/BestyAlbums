namespace BestyAlbums.Models.InputModels.Artists
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ArtistInputModel
    {
        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(maximumLength: 32, MinimumLength = 2, ErrorMessage = "Name must be between {2} and {1} characters.")]
        public string Name { get; set; }

        public DateTime Founded { get; set; }

        [Required(ErrorMessage = "Location field is required.")]
        [StringLength(maximumLength: 32, MinimumLength = 2, ErrorMessage = "Location must be between {2} and {1} characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Rating field is required.")]
        [Range(typeof(double), "0.00", "5.00", ErrorMessage = "Rating must be between {1} and {2}.")]
        public double Rating { get; set; }

        [Required(ErrorMessage = "ImageUrl field is required.")]
        [StringLength(maximumLength: 1024, MinimumLength = 2, ErrorMessage = "ImageUrl must be between {2} and {1} characters.")]
        public string ImageUrl { get; set; }
    }
}

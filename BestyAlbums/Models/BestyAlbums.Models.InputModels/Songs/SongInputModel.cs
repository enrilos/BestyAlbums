namespace BestyAlbums.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SongInputModel
    {
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Album { get; set; }
    }
}

namespace BestyAlbums.Models.InputModels.Songs
{
    using System.ComponentModel.DataAnnotations;

    public class SongInputModel
    {
        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        public string Album { get; set; }
    }
}
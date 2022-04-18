namespace BestyAlbums.Models.InputModels.Songs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddSongFormModel
    {
        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Album")]
        public string AlbumName { get; set; }

        public IEnumerable<string> Albums { get; set; }
    }
}
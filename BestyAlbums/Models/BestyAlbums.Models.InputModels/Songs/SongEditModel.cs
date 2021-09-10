namespace BestyAlbums.Models.InputModels.Songs
{
    using System.ComponentModel.DataAnnotations;

    public class SongEditModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }
    }
}

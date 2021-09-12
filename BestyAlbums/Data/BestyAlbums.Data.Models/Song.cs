namespace BestyAlbums.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        public Album Album { get; set; }
        public int? AlbumId { get; set; }
    }
}

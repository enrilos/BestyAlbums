namespace BestyAlbums.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddSongInputModel
    {
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }

        public string Album { get; set; }
    }
}

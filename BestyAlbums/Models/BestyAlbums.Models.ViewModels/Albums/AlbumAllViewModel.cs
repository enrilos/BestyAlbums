namespace BestyAlbums.Models.ViewModels.Albums
{
    using Data.Models.Enums;

    public class AlbumAllViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CoverUrl { get; set; }

        public decimal Price { get; set; }

        public int SongsCount { get; set; }

        public AlbumStatus AlbumStatus { get; set; }
    }
}

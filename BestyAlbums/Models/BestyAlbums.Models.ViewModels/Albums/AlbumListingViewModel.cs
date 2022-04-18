namespace BestyAlbums.Models.ViewModels.Albums
{
    using Data.Models.Enums;

    public class AlbumListingViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string CoverUrl { get; init; }

        public decimal Price { get; init; }

        public int SongCount { get; init; }

        public AlbumStatus AlbumStatus { get; init; }
    }
}
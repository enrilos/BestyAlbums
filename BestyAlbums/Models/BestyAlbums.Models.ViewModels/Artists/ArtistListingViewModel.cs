namespace BestyAlbums.Models.ViewModels.Artists
{
    using System;

    public class ArtistListingViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public DateTime Founded { get; init; }

        public string Location { get; init; }

        public double Rating { get; init; }

        public string ImageUrl { get; init; }
    }
}
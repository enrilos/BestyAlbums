namespace BestyAlbums.Models.ViewModels.Artists
{
    using System;

    public class ArtistAllViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Founded { get; set; }

        public string Location { get; set; }

        public double Rating { get; set; }

        public string ImageUrl { get; set; }
    }
}

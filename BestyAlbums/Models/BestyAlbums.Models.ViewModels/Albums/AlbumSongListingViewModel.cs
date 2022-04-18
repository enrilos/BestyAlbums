namespace BestyAlbums.Models.ViewModels.Albums
{
    using Data.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class AlbumSongListingViewModel
    {
        public string Name { get; init; }

        public DateTime Released { get; init; }

        public Genre Genre { get; init; }

        public string CoverUrl { get; init; }

        public decimal Price { get; init; }

        public AlbumStatus AlbumStatus { get; init; }

        public string Artist { get; init; }

        public StudioType StudioType { get; init; }

        public string Label { get; init; }

        public int? ProductionTimeInDays { get; init; }

        public IList<string> SongNames { get; init; }
    }
}
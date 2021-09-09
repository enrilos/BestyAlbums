namespace BestyAlbums.Models.ViewModels.Albums
{
    using Data.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class AlbumSongsViewModel
    {
        public string Name { get; set; }

        public DateTime Released { get; set; }

        public Genre Genre { get; set; }

        public string CoverUrl { get; set; }

        public decimal Price { get; set; }

        public AlbumStatus AlbumStatus { get; set; }

        public string Artist { get; set; }

        public StudioType StudioType { get; set; }

        public string Label { get; set; }

        public int? ProductionTimeInDays { get; set; }

        public IList<string> Songs { get; set; }
    }
}

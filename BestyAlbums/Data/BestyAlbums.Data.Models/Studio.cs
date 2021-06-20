namespace BestyAlbums.Data.Models
{
    using Enums;
    using System;
    using System.Collections.Generic;

    public class Studio
    {
        public int Id { get; set; }

        public StudioType StudioType { get; set; }

        public DateTime Founded { get; set; }

        public DateTime? Discontinued { get; set; }

        public string Headquarters { get; set; }

        public string WebsiteURL { get; set; }

        public List<Album> RecordedAlbums { get; set; } = new List<Album>();

        public List<Single> RecordedSingles { get; set; } = new List<Single>();
    }
}

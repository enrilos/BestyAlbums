namespace BestyAlbums.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Artist
    {
        public int Id { get; set; }

        public DateTime Founded { get; set; }

        public string Location { get; set; }

        public double Rating { get; set; }

        public List<Member> Members { get; set; } = new List<Member>();

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Song> Songs { get; set; } = new List<Song>();

        public List<Single> Singles { get; set; } = new List<Single>();
    }
}

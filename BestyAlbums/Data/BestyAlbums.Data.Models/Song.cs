namespace BestyAlbums.Data.Models
{
    using System;

    public class Song
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan Length { get; set; }

        public Album Album { get; set; }
        public int AlbumId { get; set; }

        public DateTime Released { get; set; }
    }
}

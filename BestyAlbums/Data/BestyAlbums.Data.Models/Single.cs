namespace BestyAlbums.Data.Models
{
    using Enums;
    using System;

    public class Single
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan Length { get; set; }

        public Genre Genre { get; set; }

        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

        public Studio Studio { get; set; }
        public int StudioId { get; set; }

        public DateTime Released { get; set; }

        public int ProductionTimeInDays { get; set; }
    }
}

namespace BestyAlbums.Web.ViewModels
{
    using Data.Models.Enums;
    using System;

    public class AddAlbumInputModel
    {
        public string Name { get; set; }

        public DateTime Released { get; set; }

        public Genre Genre { get; set; }

        public string CoverURL { get; set; }

        public decimal Price { get; set; }

        public AlbumStatus AlbumStatus { get; set; }

        //public Artist Artist { get; set; }
        //public int ArtistId { get; set; }

        //public Studio Studio { get; set; }
        //public int StudioId { get; set; }

        public string Label { get; set; }

        public int? ProductionTimeInDays { get; set; }
    }
}

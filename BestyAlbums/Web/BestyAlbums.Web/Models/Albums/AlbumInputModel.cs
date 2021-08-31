namespace BestyAlbums.Web.Models
{
    using Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AlbumInputModel
    {
        public string Name { get; set; }

        public DateTime Released { get; set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        [StringLength(maximumLength: 256, MinimumLength = 10)]
        public string CoverURL { get; set; }

        [Range(typeof(decimal), "0", "9999.99")]
        public decimal Price { get; set; }

        [EnumDataType(typeof(AlbumStatus))]
        public AlbumStatus AlbumStatus { get; set; }

        public string Artist { get; set; }

        public StudioType StudioType { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Label { get; set; }

        public int? ProductionTimeInDays { get; set; }
    }
}

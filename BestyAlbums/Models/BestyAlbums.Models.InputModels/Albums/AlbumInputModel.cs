namespace BestyAlbums.Models.InputModels.Albums
{
    using Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AlbumInputModel
    {
        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }

        public DateTime Released { get; set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        [Required]
        [StringLength(maximumLength: 1024, MinimumLength = 10)]
        public string CoverURL { get; set; }

        [Range(typeof(decimal), "0.00", "9999.99")]
        public decimal Price { get; set; }

        [EnumDataType(typeof(AlbumStatus))]
        public AlbumStatus AlbumStatus { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Artist { get; set; }

        [EnumDataType(typeof(StudioType))]
        public StudioType StudioType { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Label { get; set; }

        public int? ProductionTimeInDays { get; set; }
    }
}

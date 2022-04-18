namespace BestyAlbums.Models.InputModels.Albums
{
    using Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditAlbumFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 32, MinimumLength = 2)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(maximumLength: 256, MinimumLength = 10)]
        public string CoverUrl { get; set; }

        [Range(typeof(decimal), "0.00", "9999.99")]
        public decimal Price { get; set; }

        [EnumDataType(typeof(AlbumStatus))]
        [Display(Name = "Status")]
        public AlbumStatus AlbumStatus { get; set; }
    }
}
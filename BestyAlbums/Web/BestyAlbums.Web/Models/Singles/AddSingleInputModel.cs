namespace BestyAlbums.Web.Models
{
    using Data.Models.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddSingleInputModel
    {
        [StringLength(maximumLength: 20, MinimumLength = 2)]
        public string Name { get; set; }

        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        public string Artist { get; set; }

        public StudioType StudioType { get; set; }

        public DateTime Released { get; set; }

        public int? ProductionTimeInDays { get; set; }
    }
}
namespace BestyAlbums.Web.ViewModels
{
    using Data.Models.Enums;
    using System;

    public class AddSingleInputModel
    {
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public string Artist { get; set; }

        public StudioType StudioType { get; set; }

        public DateTime Released { get; set; }

        public int? ProductionTimeInDays { get; set; }
    }
}
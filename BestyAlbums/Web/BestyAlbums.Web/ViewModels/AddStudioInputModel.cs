namespace BestyAlbums.Web.ViewModels
{
    using Data.Models.Enums;
    using System;

    public class AddStudioInputModel
    {
        public StudioType StudioType { get; set; }

        public DateTime Founded { get; set; }

        public DateTime? Discontinued { get; set; }

        public string Headquarters { get; set; }

        public string WebsiteURL { get; set; }
    }
}

namespace BestyAlbums.Web.ViewModels
{
    using System;

    public class AddSongInputModel
    {
        public string Name { get; set; }

        public TimeSpan Length { get; set; }

        public string Album { get; set; }
    }
}

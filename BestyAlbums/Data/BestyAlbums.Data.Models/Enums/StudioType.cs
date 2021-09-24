namespace BestyAlbums.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum StudioType
    {
        [Display(Name = "RecordingStudio")]
        RecordingStudio = 0,

        [Display(Name = "TelevisionStudio")]
        TelevisionStudio = 1,

        [Display(Name = "RadioStudio")]
        RadioStudio = 2,

        [Display(Name = "MovieStudio")]
        MovieStudio = 3,
    }
}

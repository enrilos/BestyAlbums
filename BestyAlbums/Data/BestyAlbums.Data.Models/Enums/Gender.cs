namespace BestyAlbums.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Gender
    {
        [Display(Name = "Male")]
        Male = 0,

        [Display(Name = "Female")]
        Female = 1,
    }
}

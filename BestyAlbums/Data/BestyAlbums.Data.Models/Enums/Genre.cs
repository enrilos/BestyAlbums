namespace BestyAlbums.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Genre
    {
        [Display(Name = "Pop")]
        Pop = 0,

        [Display(Name = "NuMetal")]
        NuMetal = 1,

        [Display(Name = "Rap")]
        Rap = 2,

        [Display(Name = "HipHop")]
        HipHop = 3,

        [Display(Name = "AlternativeMetal")]
        AlternativeMetal = 4,

        [Display(Name = "RapMetal")]
        RapMetal = 5
    }
}

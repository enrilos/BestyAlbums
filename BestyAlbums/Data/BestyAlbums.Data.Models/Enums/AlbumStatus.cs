namespace BestyAlbums.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum AlbumStatus
    {
        [Display(Name = "InProduction")]
        InProduction,

        [Display(Name = "Unreleased")]
        Unreleased,

        [Display(Name = "Selling")]
        Selling,

        [Display(Name = "Discontinued")]
        Discontinued,
    }
}

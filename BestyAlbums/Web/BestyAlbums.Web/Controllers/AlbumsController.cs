namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Albums;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public class AlbumsController : Controller
    {
        private readonly IArtistService artistService;
        private readonly IAlbumService albumService;

        public AlbumsController(IArtistService artistService, IAlbumService albumService)
        {
            this.artistService = artistService;
            this.albumService = albumService;
        }

        public IActionResult Add()
        {
            var artists = this.artistService.GetAllNames();

            return View(artists);
        }

        [HttpPost]
        public IActionResult Add(AlbumInputModel model)
        {
            if (!this.ModelState.IsValid || this.albumService.Exists(model.Name))
            {
                return RedirectToAction("Error", "Home");
            }

            this.albumService.Add(
                model.Name,
                model.Released,
                model.Genre,
                model.CoverURL,
                model.Price,
                model.AlbumStatus,
                model.Artist,
                model.StudioType,
                model.Label,
                model.ProductionTimeInDays);

            // This should redirect to all albums after the functionality is finished.
            return RedirectToAction("Index", "Home");
        }
    }
}

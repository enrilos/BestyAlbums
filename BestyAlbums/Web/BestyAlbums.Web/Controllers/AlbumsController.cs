namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Albums;
    using BestyAlbums.Models.ViewModels.Albums;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System.Linq;

    public class AlbumsController : Controller
    {
        private readonly IArtistService artistService;
        private readonly IAlbumService albumService;

        public AlbumsController(IArtistService artistService, IAlbumService albumService)
        {
            this.artistService = artistService;
            this.albumService = albumService;
        }

        public IActionResult All()
        {
            var albums = this.albumService
                .GetAllAlbums()
                .Select(x => new AlbumAllViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    AlbumStatus = x.AlbumStatus,
                    CoverUrl = x.CoverUrl,
                    Price = x.Price
                })
                .ToList();

            return View(albums);
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

            return RedirectToAction("All", "Albums");
        }
    }
}

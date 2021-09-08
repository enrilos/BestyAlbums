namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Data.Models;
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

        public IActionResult Edit(int id)
        {
            if(!this.albumService.Exists(id))
            {
                return BadRequest();
            }

            var album = this.albumService.Get(id);

            var albumModel = new AlbumEditModel()
            {
                Name = album.Name,
                Price = album.Price,
                CoverUrl = album.CoverUrl,
                AlbumStatus = album.AlbumStatus,
                Genre = album.Genre,
                Artist = album.Artist.Name,
                Label = album.Label,
                ProductionTimeInDays = album.ProductionTimeInDays,
                Released = album.Released,
                StudioType = album.StudioType,

            };

            return View(albumModel);
        }

        [HttpPost]
        public IActionResult Edit(AlbumEditModel model)
        {
            if (!this.albumService.Exists(model.Id))
            {
                return BadRequest();
            }
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            this.albumService.Edit(model);

            return RedirectToAction("All", "Albums");
        }
    }
}

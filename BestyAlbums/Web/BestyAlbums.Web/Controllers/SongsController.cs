namespace BestyAlbums.Web.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using BestyAlbums.Web.ViewModels;
    using System;

    public class SongsController : Controller
    {
        private readonly ISongService songService;
        private readonly IAlbumService albumService;

        public SongsController(ISongService songService, IAlbumService albumService)
        {
            this.songService = songService;
            this.albumService = albumService;
        }

        public IActionResult Add()
        {
            var albums = this.albumService.GetAllAlbums();

            return View(albums);
        }

        [HttpPost]
        public IActionResult Add(AddSongInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            try
            {
                this.songService.Add(model.Name, model.Album);
            }
            catch (ArgumentNullException)
            {
                return RedirectToAction("Error", "Home");
            }
            catch (InvalidOperationException)
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Success", "Home");
        }
    }
}

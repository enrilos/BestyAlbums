namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Songs;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
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
            var albums = this.albumService.GetAllAlbumNames();

            return View(albums);
        }

        [HttpPost]
        public IActionResult Add(SongInputModel model)
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

            // This should redirect to all songs after the functionality is finished.
            return RedirectToAction("Index", "Home");
        }
    }
}

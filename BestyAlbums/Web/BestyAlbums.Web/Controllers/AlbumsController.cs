﻿namespace BestyAlbums.Web.Controllers
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

        public IActionResult All()
        {
            var albums = this.albumService.GetAllAlbums();

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

        public IActionResult Info(int id)
        {
            if (!this.albumService.Exists(id))
            {
                return BadRequest();
            }

            var albumSongs = this.albumService.GetAlbumSongs(id);

            return View(albumSongs);
        }

        public IActionResult Delete(int id)
        {
            if (!this.albumService.Exists(id))
            {
                return BadRequest();
            }

            this.albumService.Delete(id);

            return RedirectToAction("All", "Albums");
        }
    }
}

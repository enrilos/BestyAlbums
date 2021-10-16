﻿namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Artists;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public class ArtistsController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistsController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult All()
        {
            var artists = artistService.GetAll();

            return View(artists);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ArtistInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View();
            }

            if (this.artistService.Exists(model.Name))
            {
                return BadRequest();
            }

            this.artistService.Add(model.Name, model.Founded, model.Location, model.Rating, model.ImageUrl);

            return RedirectToAction("All", "Artists");
        }

        public IActionResult Edit(int id)
        {
            var artist = this.artistService.GetArtistById(id);

            if(artist == null)
            {
                return BadRequest();
            }

            var artistModel = new ArtistEditModel()
            {
                Name = artist.Name,
                Founded = artist.Founded,
                Location = artist.Location,
                Rating = artist.Rating,
                ImageUrl = artist.ImageUrl
            };

            return View(artistModel);
        }

        [HttpPost]
        public IActionResult Edit(ArtistEditModel model)
        {
            if (!this.artistService.Exists(model.Id))
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.artistService.Edit(model);

            return RedirectToAction("All", "Artists");
        }

        public IActionResult Delete(int id)
        {
            if (!this.artistService.Exists(id))
            {
                return BadRequest();
            }

            this.artistService.Delete(id);

            return RedirectToAction("All", "Artists");
        }
    }
}

namespace BestyAlbums.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;
    using System.Linq;

    public class ArtistsController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistsController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult All()
        {
            var artists = artistService
                .GetAll()
                .Select(a => new ArtistAllViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Founded = a.Founded,
                    Location = a.Location,
                    Rating = a.Rating,
                    ImageUrl = a.ImageUrl
                })
                .ToList();

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
                return RedirectToAction("Error", "Home");
            }

            if (this.artistService.Exists(model.Id))
            {
                return RedirectToAction("ArtistExistsError", "Artists");
            }

            this.artistService.Add(model.Name, model.Founded, model.Location, model.Rating, model.ImageUrl);

            return RedirectToAction("Success", "Home");
        }

        public IActionResult Edit(int id)
        {
            var artist = this.artistService.GetArtistById(id);
            var artistModel = new ArtistInputModel
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
        public IActionResult Edit(ArtistInputModel model)
        {
            if (!this.artistService.Exists(model.Id))
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var artist = new Artist
            {
                Id = model.Id,
                Name = model.Name,
                Founded = model.Founded,
                Location = model.Location,
                Rating = model.Rating,
                ImageUrl = model.ImageUrl
            };

            this.artistService.Edit(artist);

            return RedirectToAction("Success", "Home");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult ArtistExistsError()
        {
            return View();
        }
    }
}

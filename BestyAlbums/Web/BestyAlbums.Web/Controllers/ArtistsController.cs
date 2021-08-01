namespace BestyAlbums.Web.Controllers
{
    using Services.Contracts;
    using ViewModels;
    using Microsoft.AspNetCore.Mvc;
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
            // AutoMapper is optional.
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

            if (this.artistService.Exists(model.Name))
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

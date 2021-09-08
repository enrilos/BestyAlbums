namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Artists;
    using BestyAlbums.Models.ViewModels.Artists;
    using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction("Error", "Home");
            }

            this.artistService.Edit(model);

            return RedirectToAction("All", "Artists");
        }
    }
}

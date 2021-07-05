namespace BestyAlbums.Web.Controllers
{
    using Services.Contracts;
    using ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ArtistsController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistsController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddArtistInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            this.artistService.Add(model.Name, model.Founded, model.Location, model.Rating);

            return RedirectToAction("Success", "Artists");
        }    

        public IActionResult Success()
        {
            return View();
        }
    }
}

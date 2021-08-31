namespace BestyAlbums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using Models;

    public class SinglesController : Controller
    {
        private readonly ISingleService singleService;
        private readonly IArtistService artistService;

        public SinglesController(ISingleService singleService, IArtistService artistService)
        {
            this.singleService = singleService;
            this.artistService = artistService;
        }

        public IActionResult Add()
        {
            var allArtists = this.artistService.GetAllNames();

            return View(allArtists);
        }

        [HttpPost]
        public IActionResult Add(SingleInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            this.singleService.Add(model.Name, model.Genre, model.Artist, model.StudioType, model.Released, model.ProductionTimeInDays);

            return RedirectToAction("Success", "Home");
        }
    }
}

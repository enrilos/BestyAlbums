namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

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
    }
}

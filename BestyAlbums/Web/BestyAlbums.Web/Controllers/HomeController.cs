namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IAlbumService albumService;

        public HomeController(IAlbumService albumService)
        {
            this.albumService = albumService;
        }

        public IActionResult Index()
        {
            var topThreeLatestAlbums = this.albumService.GetTopThreeLatestAlbums();

            return View(topThreeLatestAlbums);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
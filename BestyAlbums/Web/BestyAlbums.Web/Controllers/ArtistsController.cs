namespace BestyAlbums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ArtistsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}

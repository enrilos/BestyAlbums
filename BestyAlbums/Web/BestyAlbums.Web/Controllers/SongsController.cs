namespace BestyAlbums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SongsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}

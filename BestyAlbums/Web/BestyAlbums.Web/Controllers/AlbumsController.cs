namespace BestyAlbums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AlbumsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}

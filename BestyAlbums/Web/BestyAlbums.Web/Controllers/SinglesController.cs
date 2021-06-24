namespace BestyAlbums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SinglesController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}

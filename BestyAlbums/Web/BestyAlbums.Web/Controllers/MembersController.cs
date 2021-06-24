namespace BestyAlbums.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MembersController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}

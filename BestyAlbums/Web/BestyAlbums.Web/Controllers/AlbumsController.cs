namespace BestyAlbums.Web.Controllers
{
    using ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class AlbumsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddAlbumInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            // add

            return RedirectToAction("Success", "Home");
        }
    }
}

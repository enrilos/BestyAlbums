namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class ArtistsController : Controller
    {
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
            return RedirectToAction("Success", "Artists");
        }    

        public IActionResult Success()
        {
            return View();
        }
    }
}

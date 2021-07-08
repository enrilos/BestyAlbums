namespace BestyAlbums.Web.Controllers
{
    using ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public class StudiosController : Controller
    {
        private readonly IStudioService studioService;

        public StudiosController(IStudioService studioService)
        {
            this.studioService = studioService;
        }

        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(AddStudioInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            this.studioService.Add(model.StudioType, model.Founded, model.Discontinued, model.Headquarters, model.WebsiteURL);

            return RedirectToAction("Success", "Home");
        }
    }
}

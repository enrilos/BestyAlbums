namespace BestyAlbums.Web.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public class MembersController : Controller
    {
        private readonly IMemberService memberService;
        private readonly IArtistService artistService;

        public MembersController(IMemberService memberService, IArtistService artistService)
        {
            this.memberService = memberService;
            this.artistService = artistService;
        }

        public IActionResult Add()
        {
            var artistsNames = artistService.GetAllNames();

            return View(artistsNames);
        }

        [HttpPost]
        public IActionResult Add(AddMemberInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            this.memberService.Add(model.FirstName, model.LastName, model.BirthDate, model.Joined, model.Left, model.Gender, model.ImageURL);

            return RedirectToAction("Success", "Home");
        }
    }
}

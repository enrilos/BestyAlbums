namespace BestyAlbums.Web.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels;

    public class MembersController : Controller
    {
        private readonly IMemberService memberService;

        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddMemberInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Success", "Home");
        }
    }
}

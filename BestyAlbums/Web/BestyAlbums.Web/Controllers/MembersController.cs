namespace BestyAlbums.Web.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Linq;
    using BestyAlbums.Web.Models.Members;

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

            var artist = this.artistService.GetArtistByName(model.Artist);
            this.memberService.Add(model.FirstName, model.LastName, model.BirthDate, model.Joined, model.Left, model.Gender, model.ImageURL, artist);

            return RedirectToAction("Success", "Home");
        }

        public IActionResult All()
        {
            var members = memberService.GetAll()
                .Select(x => new MemberAllViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    Joined = x.Joined,
                    Left = x.Left,
                    Gender = x.Gender,
                    ImageURL = x.ImageURL,
                    Artist = x.Artist.Name
                })
                .ToList();

            return View(members);
        }
    }
}

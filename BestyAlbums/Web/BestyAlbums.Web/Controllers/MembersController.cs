namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Members;
    using BestyAlbums.Models.ViewModels.Members;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System.Linq;

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
        public IActionResult Add(MemberInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var artist = this.artistService.GetArtistByName(model.Artist);
            this.memberService.Add(model.FirstName, model.LastName, model.BirthDate, model.Joined, model.Left, model.Gender, model.ImageUrl, artist);

            return RedirectToAction("All", "Members");
        }

        public IActionResult All()
        {
            var members = memberService.GetAll()
                .Select(x => new MemberAllViewModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate.ToString("yyyy-MM-dd"),
                    Joined = x.Joined.ToString("yyyy-MM-dd"),
                    Left = x.Left?.ToString("yyyy-MM-dd"),
                    Gender = x.Gender,
                    ImageUrl = x.ImageUrl,
                    Artist = x.Artist.Name
                })
                .ToList();

            return View(members);
        }

        public IActionResult Edit(int id)
        {
            var member = this.memberService.Get(id);

            if (member == null)
            {
                return BadRequest();
            }

            var memberInputModel = new MemberEditModel()
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                BirthDate = member.BirthDate,
                Joined = member.Joined,
                Left = member.Left,
                Gender = member.Gender,
                ImageUrl = member.ImageUrl,
                Artist = member.Artist.Name
            };

            return View(memberInputModel);
        }

        [HttpPost]
        public IActionResult Edit(MemberEditModel model)
        {
            if(!this.memberService.Exists(model.Id))
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            this.memberService.Edit(model);

            return RedirectToAction("All", "Members");
        }
    }
}

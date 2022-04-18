namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Members;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public class MembersController : Controller
    {
        private readonly IMemberService memberService;
        private readonly IArtistService artistService;

        public MembersController(
            IMemberService memberService,
            IArtistService artistService)
        {
            this.memberService = memberService;
            this.artistService = artistService;
        }

        public IActionResult All()
        {
            var members = memberService.GetAll();

            return View(members);
        }

        public IActionResult Add()
        {
            var artistsNames = artistService.GetNames();

            var memberModel = new AddMemberFormModel
            {
                Artists = artistsNames
            };

            return View(memberModel);
        }

        [HttpPost]
        public IActionResult Add(AddMemberFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Artists = artistService.GetNames();

                return View(model);
            }

            if (!artistService.Exists(model.ArtistName))
            {
                return NotFound();
            }

            var artistId = artistService.GetIdByName(model.ArtistName);

            memberService
                .Add(
                model.FirstName,
                model.LastName,
                model.BirthDate,
                model.Joined,
                model.Left,
                model.Gender,
                model.ImageUrl,
                artistId);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            if (!memberService.Exists(id))
            {
                return NotFound();
            }

            var memberEditModel = memberService.GetEditModel(id);

            return View(memberEditModel);
        }

        [HttpPost]
        public IActionResult Edit(EditMemberFormModel model)
        {
            if(!memberService.Exists(model.Id))
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            memberService.Edit(
                model.Id,
                model.FirstName,
                model.LastName,
                model.BirthDate,
                model.Joined,
                model.Left,
                model.Gender,
                model.ImageUrl);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            if (!memberService.Exists(id))
            {
                return NotFound();
            }

            memberService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
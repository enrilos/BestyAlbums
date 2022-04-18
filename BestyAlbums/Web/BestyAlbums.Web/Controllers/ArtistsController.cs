namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Artists;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public class ArtistsController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistsController(IArtistService artistService)
            => this.artistService = artistService;

        public IActionResult All()
        {
            var artists = artistService.GetAll();

            return View(artists);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddArtistFormModel model)
        {
            if (artistService.Exists(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Artist with that name already exists!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            artistService.Add(
                model.Name,
                model.Founded,
                model.Location,
                model.Rating,
                model.ImageUrl);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            if (!artistService.Exists(id))
            {
                return NotFound();
            }

            var artistEditModel = artistService.GetEditModel(id);

            return View(artistEditModel);
        }

        [HttpPost]
        public IActionResult Edit(EditArtistFormModel model)
        {
            if (!artistService.Exists(model.Id))
            {
                return NotFound();
            }
            if (artistService.Exists(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Artist with that name already exists!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            artistService.Edit(
                model.Id,
                model.Name,
                model.Founded,
                model.Location,
                model.Rating,
                model.ImageUrl);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            if (!artistService.Exists(id))
            {
                return NotFound();
            }

            artistService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
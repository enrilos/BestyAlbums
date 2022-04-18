namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Songs;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System.Linq;

    public class SongsController : Controller
    {
        private readonly ISongService songService;
        private readonly IAlbumService albumService;

        public SongsController(
            ISongService songService,
            IAlbumService albumService)
        {
            this.songService = songService;
            this.albumService = albumService;
        }

        public IActionResult All()
        {
            var songs = songService
                .GetAll()
                .ToList();

            return View(songs);
        }

        public IActionResult Add()
        {
            var albums = albumService.GetNames();

            return View(albums);
        }

        [HttpPost]
        public IActionResult Add(AddSongFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Albums = albumService.GetNames();

                return View(model);
            }

            if (!albumService.Exists(model.AlbumName))
            {
                return NotFound();
            }

            var result = songService.Add(model.Name, model.AlbumName);

            if (!result)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            if (!songService.Exists(id))
            {
                return NotFound();
            }

            var songEditModel = songService.GetEditModel(id);

            return View(songEditModel);
        }

        [HttpPost]
        public IActionResult Edit(EditSongFormModel model)
        {
            if (!songService.Exists(model.Id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var editResult = songService.Edit(
                model.Id,
                model.Name);

            if (!editResult)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int id)
        {
            if (!songService.Exists(id))
            {
                return NotFound();
            }

            songService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
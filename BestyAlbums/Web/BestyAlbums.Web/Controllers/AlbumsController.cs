namespace BestyAlbums.Web.Controllers
{
    using BestyAlbums.Models.InputModels.Albums;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;

    public class AlbumsController : Controller
    {
        private readonly IArtistService artistService;
        private readonly IAlbumService albumService;

        public AlbumsController(
            IArtistService artistService,
            IAlbumService albumService)
        {
            this.artistService = artistService;
            this.albumService = albumService;
        }

        public IActionResult All()
        {
            var albums = albumService.GetAll();

            return View(albums);
        }

        public IActionResult Add()
        {
            var artistNames = artistService.GetNames();

            var albumModel = new AddAlbumFormModel
            {
                ArtistNames = artistNames
            };

            return View(albumModel);
        }

        [HttpPost]
        public IActionResult Add(AddAlbumFormModel model)
        {
            if (!artistService.Exists(model.Artist))
            {
                return NotFound();
            }
            if (albumService.Exists(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Album with that name already exists!");
            }
            if (!ModelState.IsValid)
            {
                model.ArtistNames = artistService.GetNames();

                return View(model);
            }

            var id = albumService.Add(
                model.Name,
                model.Released,
                model.Genre,
                model.CoverUrl,
                model.Price,
                model.AlbumStatus,
                model.Artist,
                model.StudioType,
                model.Label,
                model.ProductionTimeInDays);

            if (id == 0)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Info), new { id = id });
        }

        public IActionResult Edit(int id)
        {
            if(!albumService.Exists(id))
            {
                return NotFound();
            }

            var albumModel = albumService.GetEditModel(id);

            return View(albumModel);
        }

        [HttpPost]
        public IActionResult Edit(EditAlbumFormModel model)
        {
            if (!albumService.Exists(model.Id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            albumService.Edit(
                model.Id,
                model.Name,
                model.CoverUrl,
                model.Price,
                model.AlbumStatus);

            return RedirectToAction(nameof(Info), new { id = model.Id });
        }

        public IActionResult Info(int id)
        {
            if (!albumService.Exists(id))
            {
                return NotFound();
            }

            var albumSongs = albumService.GetSongs(id);

            return View(albumSongs);
        }

        public IActionResult Delete(int id)
        {
            if (!albumService.Exists(id))
            {
                return NotFound();
            }

            albumService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
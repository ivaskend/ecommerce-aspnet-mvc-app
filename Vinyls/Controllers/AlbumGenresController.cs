using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data;
using Vinyls.Data.Services;
using Vinyls.Models;

namespace Vinyls.Controllers
{
    public class AlbumGenresController : Controller
    {
        private readonly IAlbumGenresService _service;

        public AlbumGenresController(IAlbumGenresService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allAlbumGenres = await _service.GetAllAsync();
            return View(allAlbumGenres);
        }

        //Get: AlbumGenres/Create

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description")]AlbumGenre albumGenre)
        {
            if (!ModelState.IsValid) return View(albumGenre);
            await _service.AddAsync(albumGenre);
            return RedirectToAction(nameof(Index));
        }

        //Get: AlbumGenres/Details/Id

        public async Task<IActionResult> Details(int id)
        {
            var albumGenresDetails = await _service.GetByIdAsync(id);
            if (albumGenresDetails == null) return View("NotFound");
            return View(albumGenresDetails);
        }

        //Get:AlbumGenres/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var albumGenresDetails = await _service.GetByIdAsync(id);
            if (albumGenresDetails == null) return View("NotFound");
            return View(albumGenresDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] AlbumGenre albumGenre)
        {
            if (!ModelState.IsValid) return View(albumGenre);
            await _service.UpdateAsync(id, albumGenre);
            return RedirectToAction(nameof(Index));
        }
        //Get:AlbumGenres/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var albumGenresDetails = await _service.GetByIdAsync(id);
            if (albumGenresDetails == null) return View("NotFound");
            return View(albumGenresDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var albumGenresDetails = await _service.GetByIdAsync(id);
            if (albumGenresDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

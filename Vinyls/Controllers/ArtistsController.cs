using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data;
using Vinyls.Data.Services;
using Vinyls.Models;

namespace Vinyls.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistsService _service;

        public ArtistsController(IArtistsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get:Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.AddAsync(artist);
            return RedirectToAction(nameof(Index));
        }

        //Get:Artist/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");
            return View(artistDetails);
        }

        //Get:Artists/Update
        public async Task<IActionResult> Edit(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");
            return View(artistDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return View(artist);
            }
            await _service.UpdateAsync(id,artist);
            return RedirectToAction(nameof(Index));
        }

        //Get:Artists/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");
            return View(artistDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artistDetails = await _service.GetByIdAsync(id);
            if (artistDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class VinylsController : Controller
    {
        private readonly IVinylsService _service;

        public VinylsController(IVinylsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allVinyls = await _service.GetAllAsync(n => n.AlbumGenre);
            allVinyls = await _service.GetAllAsync(m => m.RecordLabel);
            return View(allVinyls);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allVinyls = await _service.GetAllAsync(n => n.AlbumGenre);
            allVinyls = await _service.GetAllAsync(m => m.RecordLabel);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allVinyls.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allVinyls);
        }


        //GET:Vinyls/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var vinylDetail = await _service.GetVinylByIdAsync(id);
            return View(vinylDetail);
        }
        //GET:Vinyls/Create
        public async Task<IActionResult> Create()
        {
            var vinylDropdownsData = await _service.GetNewVinylDropdownsValues();

            ViewBag.AlbumGenres = new SelectList(vinylDropdownsData.AlbumGenres, "Id", "Name");
            ViewBag.RecordLabels = new SelectList(vinylDropdownsData.RecordLabels, "Id", "FullName");
            ViewBag.Artists = new SelectList(vinylDropdownsData.Artists, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewVinylVM vinyl)
        {
            if (!ModelState.IsValid)
            {
                var vinylDropdownsData = await _service.GetNewVinylDropdownsValues();

                ViewBag.AlbumGenres = new SelectList(vinylDropdownsData.AlbumGenres, "Id", "Name");
                ViewBag.RecordLabels = new SelectList(vinylDropdownsData.RecordLabels, "Id", "FullName");
                ViewBag.Artists = new SelectList(vinylDropdownsData.Artists, "Id", "FullName");

                return View(vinyl);
            }

            await _service.AddNewVinylAsync(vinyl);
            return RedirectToAction(nameof(Index));

        }
        //GET:Vinyls/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var vinylDetails = await _service.GetVinylByIdAsync(id);

            if (vinylDetails == null) return View("NotFound");

            var response = new NewVinylVM()
            {
                Id = vinylDetails.Id,
                Name = vinylDetails.Name,
                Description = vinylDetails.Description,
                Price = vinylDetails.Price,
                Details = vinylDetails.Details,
                ImageURL = vinylDetails.ImageURL,
                AlbumFormat = vinylDetails.AlbumFormat,
                AlbumGenreId = vinylDetails.AlbumGenreId,
                RecordLabelId = vinylDetails.RecordLabelId,
                ArtistIds = vinylDetails.Artist_Vinyls.Select(n => n.ArtistId).ToList(),
            };

            var vinylDropdownsData = await _service.GetNewVinylDropdownsValues();
            ViewBag.AlbumGenres = new SelectList(vinylDropdownsData.AlbumGenres, "Id", "Name");
            ViewBag.RecordLabels = new SelectList(vinylDropdownsData.RecordLabels, "Id", "FullName");
            ViewBag.Artists = new SelectList(vinylDropdownsData.Artists, "Id", "FullName");

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewVinylVM vinyl)
        {
            if (id != vinyl.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var vinylDropdownsData = await _service.GetNewVinylDropdownsValues();

                ViewBag.AlbumGenres = new SelectList(vinylDropdownsData.AlbumGenres, "Id", "Name");
                ViewBag.RecordLabels = new SelectList(vinylDropdownsData.RecordLabels, "Id", "FullName");
                ViewBag.Artists = new SelectList(vinylDropdownsData.Artists, "Id", "FullName");

                return View(vinyl);
            }

            await _service.UpdateVinylAsync(vinyl);
            return RedirectToAction(nameof(Index));

        }

    }
}

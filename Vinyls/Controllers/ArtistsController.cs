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
            var data = await _service.GetAll();
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
            _service.Add(artist);
            return RedirectToAction(nameof(Index));
        }
    } 
}

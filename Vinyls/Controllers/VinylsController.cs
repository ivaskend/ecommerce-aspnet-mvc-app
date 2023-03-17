using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data;
using Vinyls.Data.Services;

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
            var allVinyls = await _service.GetAllAsync(n=> n.AlbumGenre);
            allVinyls = await _service.GetAllAsync(m=>m.RecordLabel);
            return View(allVinyls);
        }

        //GET:Vinyls/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var vinylDetail = await _service.GetVinylByIdAsync(id);
            return View(vinylDetail);
        }

    }
}

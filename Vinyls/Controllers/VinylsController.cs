using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data;

namespace Vinyls.Controllers
{
    public class VinylsController : Controller
    {
        private readonly AppDbContext _context;

        public VinylsController(Data.AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allVinyls = await _context.Vinyls.Include(n=>n.AlbumGenre).ToListAsync();
            allVinyls = await _context.Vinyls.Include(m => m.RecordLabel).ToListAsync();
            return View(allVinyls);
        }
    }
}

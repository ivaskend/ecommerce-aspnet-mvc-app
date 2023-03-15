using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data;

namespace Vinyls.Controllers
{
    public class AlbumGenresController : Controller
    {
        private readonly AppDbContext _context;

        public AlbumGenresController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allAlbumGenres = await _context.AlbumGenres.ToListAsync();
            return View(allAlbumGenres);
        }
    }
}

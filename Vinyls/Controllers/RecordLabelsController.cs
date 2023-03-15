using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data;

namespace Vinyls.Controllers
{
    public class RecordLabelsController : Controller
    {
        private readonly AppDbContext _context;

        public RecordLabelsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allRecordLabels = await _context.RecordLabels.ToListAsync();
            return View(allRecordLabels);
        }
    }
}

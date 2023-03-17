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
    public class RecordLabelsController : Controller
    {
        private readonly IRecordLabelsService _service;

        public RecordLabelsController(IRecordLabelsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allRecordLabels = await _service.GetAllAsync();
            return View(allRecordLabels);
        }
        //GET: RecordLabels/Details/Id

        public async Task<IActionResult> Details(int id)
        {
            var recordLabelDetails = await _service.GetByIdAsync(id);
            if (recordLabelDetails == null) return View("NotFound");
            return View(recordLabelDetails);
        }
        //GET:RecordLabels/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")]RecordLabel recordLabel)
        {
            if (!ModelState.IsValid) return View(recordLabel);
            await _service.AddAsync(recordLabel);
            return RedirectToAction(nameof(Index));
        }

        //GET:RecordLabels/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var recordLabelDetails = await _service.GetByIdAsync(id);
            if (recordLabelDetails == null) return View("NotFound");
            return View(recordLabelDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL, FullName, Bio")] RecordLabel recordLabel)
        {
            if (!ModelState.IsValid) return View(recordLabel);

            if(id == recordLabel.Id)
            {
                await _service.UpdateAsync(id,recordLabel);
                return RedirectToAction(nameof(Index));
            }
            return View(recordLabel);
        }

        //GET:RecordLabels/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var recordLabelDetails = await _service.GetByIdAsync(id);
            if (recordLabelDetails == null) return View("NotFound");
            return View(recordLabelDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordLabelDetails = await _service.GetByIdAsync(id);
            if (recordLabelDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

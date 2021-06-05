using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetSystem.Entity;
using NetSystem.Models;

namespace NetSystem.Controllers
{
    public class UnitOfMeasurementsController : Controller
    {
        private readonly AppDbContext _context;

        public UnitOfMeasurementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UnitOfMeasurements
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnitOfMeasurements.ToListAsync());
        }

        // GET: UnitOfMeasurements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitOfMeasurement = await _context.UnitOfMeasurements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unitOfMeasurement == null)
            {
                return NotFound();
            }

            return View(unitOfMeasurement);
        }

        // GET: UnitOfMeasurements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitOfMeasurements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Unit,Description")] UnitOfMeasurement unitOfMeasurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitOfMeasurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitOfMeasurement);
        }

        // GET: UnitOfMeasurements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitOfMeasurement = await _context.UnitOfMeasurements.FindAsync(id);
            if (unitOfMeasurement == null)
            {
                return NotFound();
            }
            return View(unitOfMeasurement);
        }

        // POST: UnitOfMeasurements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Unit,Description")] UnitOfMeasurement unitOfMeasurement)
        {
            if (id != unitOfMeasurement.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitOfMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitOfMeasurementExists(unitOfMeasurement.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(unitOfMeasurement);
        }

        // GET: UnitOfMeasurements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitOfMeasurement = await _context.UnitOfMeasurements
                .FirstOrDefaultAsync(m => m.ID == id);
            if (unitOfMeasurement == null)
            {
                return NotFound();
            }

            return View(unitOfMeasurement);
        }

        // POST: UnitOfMeasurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitOfMeasurement = await _context.UnitOfMeasurements.FindAsync(id);
            _context.UnitOfMeasurements.Remove(unitOfMeasurement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitOfMeasurementExists(int id)
        {
            return _context.UnitOfMeasurements.Any(e => e.ID == id);
        }
    }
}

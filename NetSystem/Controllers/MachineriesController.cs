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
    public class MachineriesController : Controller
    {
        private readonly AppDbContext _context;

        public MachineriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Machineries
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Machineries.Include(m => m.Coding);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Machineries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinery = await _context.Machineries
                .Include(m => m.Coding)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (machinery == null)
            {
                return NotFound();
            }

            return View(machinery);
        }

        // GET: Machineries/Create
        public IActionResult Create()
        {
            ViewData["CodeID_FK"] = new SelectList(_context.Codings, "ID", "CodeTitle");
            return View();
        }

        // POST: Machineries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IsActive,IsDelete,CodeID_FK,MachineryTitle,Description")] Machinery machinery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machinery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodeID_FK"] = new SelectList(_context.Codings, "ID", "CodeTitle", machinery.CodeID_FK);
            return View(machinery);
        }

        // GET: Machineries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinery = await _context.Machineries.FindAsync(id);
            if (machinery == null)
            {
                return NotFound();
            }
            ViewData["CodeID_FK"] = new SelectList(_context.Codings, "ID", "CodeTitle", machinery.CodeID_FK);
            return View(machinery);
        }

        // POST: Machineries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IsActive,IsDelete,CodeID_FK,MachineryTitle,Description")] Machinery machinery)
        {
            if (id != machinery.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machinery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineryExists(machinery.ID))
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
            ViewData["CodeID_FK"] = new SelectList(_context.Codings, "ID", "CodeTitle", machinery.CodeID_FK);
            return View(machinery);
        }

        // GET: Machineries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machinery = await _context.Machineries
                .Include(m => m.Coding)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (machinery == null)
            {
                return NotFound();
            }

            return View(machinery);
        }

        // POST: Machineries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machinery = await _context.Machineries.FindAsync(id);
            _context.Machineries.Remove(machinery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineryExists(int id)
        {
            return _context.Machineries.Any(e => e.ID == id);
        }
    }
}

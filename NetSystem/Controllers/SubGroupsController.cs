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
    public class SubGroupsController : Controller
    {
        private readonly AppDbContext _context;

        public SubGroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SubGroups
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SubGroups.Include(s => s.Company).Include(s => s.Group);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SubGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroups
                .Include(s => s.Company)
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subGroup == null)
            {
                return NotFound();
            }

            return View(subGroup);
        }

        // GET: SubGroups/Create
        public IActionResult Create()
        {
            ViewData["CompanyID_FK"] = new SelectList(_context.Companies, "ID", "CompanyTiltle");
            ViewData["GroupID_FK"] = new SelectList(_context.Groups, "ID", "GroupTitle");
            return View();
        }

        // POST: SubGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CompanyID_FK,GroupID_FK,SubGroupIndex,SubGroupTitle,Description")] SubGroup subGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyID_FK"] = new SelectList(_context.Companies, "ID", "CompanyTiltle", subGroup.CompanyID_FK);
            ViewData["GroupID_FK"] = new SelectList(_context.Groups, "ID", "GroupTitle", subGroup.GroupID_FK);
            return View(subGroup);
        }

        // GET: SubGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroups.FindAsync(id);
            if (subGroup == null)
            {
                return NotFound();
            }
            ViewData["CompanyID_FK"] = new SelectList(_context.Companies, "ID", "CompanyTiltle", subGroup.CompanyID_FK);
            ViewData["GroupID_FK"] = new SelectList(_context.Groups, "ID", "GroupTitle", subGroup.GroupID_FK);
            return View(subGroup);
        }

        // POST: SubGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CompanyID_FK,GroupID_FK,SubGroupIndex,SubGroupTitle,Description")] SubGroup subGroup)
        {
            if (id != subGroup.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubGroupExists(subGroup.ID))
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
            ViewData["CompanyID_FK"] = new SelectList(_context.Companies, "ID", "CompanyTiltle", subGroup.CompanyID_FK);
            ViewData["GroupID_FK"] = new SelectList(_context.Groups, "ID", "GroupTitle", subGroup.GroupID_FK);
            return View(subGroup);
        }

        // GET: SubGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subGroup = await _context.SubGroups
                .Include(s => s.Company)
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subGroup == null)
            {
                return NotFound();
            }

            return View(subGroup);
        }

        // POST: SubGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subGroup = await _context.SubGroups.FindAsync(id);
            _context.SubGroups.Remove(subGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubGroupExists(int id)
        {
            return _context.SubGroups.Any(e => e.ID == id);
        }
    }
}

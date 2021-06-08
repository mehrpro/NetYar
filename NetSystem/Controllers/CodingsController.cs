using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetSystem.Entity;
using NetSystem.Models;

namespace NetSystem.Controllers
{
    public class CodingsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CodingsController(AppDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Codings
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Codings.Include(c => c.ApplicationUser).Include(c => c.Company).Include(c => c.Group).Include(c => c.SubGroup);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Codings/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coding = await _context.Codings
                .Include(c => c.ApplicationUser)
                .Include(c => c.Company)
                .Include(c => c.Group)
                .Include(c => c.SubGroup)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coding == null)
            {
                return NotFound();
            }

            return View(coding);
        }

        // GET: Codings/Create
        public IActionResult Create()
        {
            ViewData["CompanyID_FK"] = new SelectList(_context.Companies, "ID", "CompanyTiltle");
            ViewData["GroupID_FK"] = new SelectList(_context.Groups, "ID", "GroupTitle");
            ViewData["SubGroupID_FK"] = new SelectList(_context.SubGroups, "ID", "SubGroupTitle");
            return View();
        }

        // POST: Codings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyID_FK,GroupID_FK,SubGroupID_FK,CodeIndex,Code,CodeTitle,Description")] Coding coding)
        {
            if (ModelState.IsValid)
            {
                coding.UserID_FK = _userManager.GetUserId(HttpContext.User);
                _context.Add(coding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyID_FK"] = new SelectList(_context.Companies, "ID", "CompanyTiltle", coding.CompanyID_FK);
            ViewData["GroupID_FK"] = new SelectList(_context.Groups, "ID", "GroupTitle", coding.GroupID_FK);
            ViewData["SubGroupID_FK"] = new SelectList(_context.SubGroups, "ID", "SubGroupTitle", coding.SubGroupID_FK);
            return View(coding);
        }

        // GET: Codings/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coding = await _context.Codings.FindAsync(id);
            if (coding == null)
            {
                return NotFound();
            }
            ViewData["UserID_FK"] = new SelectList(_context.ApplicationUsers, "Id", "Id", coding.UserID_FK);
            ViewData["CompanyID_FK"] = new SelectList(_context.Companies, "ID", "CompanyTiltle", coding.CompanyID_FK);
            ViewData["GroupID_FK"] = new SelectList(_context.Groups, "ID", "GroupTitle", coding.GroupID_FK);
            ViewData["SubGroupID_FK"] = new SelectList(_context.SubGroups, "ID", "SubGroupTitle", coding.SubGroupID_FK);
            return View(coding);
        }

        // POST: Codings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,CompanyID_FK,GroupID_FK,SubGroupID_FK,UserID_FK,CodeIndex,Code,CodeTitle,Description")] Coding coding)
        {
            if (id != coding.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodingExists(coding.ID))
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
            ViewData["UserID_FK"] = new SelectList(_context.ApplicationUsers, "Id", "Id", coding.UserID_FK);
            ViewData["CompanyID_FK"] = new SelectList(_context.Companies, "ID", "CompanyTiltle", coding.CompanyID_FK);
            ViewData["GroupID_FK"] = new SelectList(_context.Groups, "ID", "GroupTitle", coding.GroupID_FK);
            ViewData["SubGroupID_FK"] = new SelectList(_context.SubGroups, "ID", "SubGroupTitle", coding.SubGroupID_FK);
            return View(coding);
        }

        // GET: Codings/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coding = await _context.Codings
                .Include(c => c.ApplicationUser)
                .Include(c => c.Company)
                .Include(c => c.Group)
                .Include(c => c.SubGroup)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (coding == null)
            {
                return NotFound();
            }

            return View(coding);
        }

        // POST: Codings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var coding = await _context.Codings.FindAsync(id);
            _context.Codings.Remove(coding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodingExists(long id)
        {
            return _context.Codings.Any(e => e.ID == id);
        }
    }
}

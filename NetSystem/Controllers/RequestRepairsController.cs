﻿using System;
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
    public class RequestRepairsController : Controller
    {
        private readonly AppDbContext _context;

        public RequestRepairsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RequestRepairs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RequestRepairs.Include(r => r.Applicant).Include(r => r.ApplicationUser).Include(r => r.Machinery).Include(r => r.TypeofRepair);
            return View(await appDbContext.ToListAsync());
        }

        // GET: RequestRepairs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestRepair = await _context.RequestRepairs
                .Include(r => r.Applicant)
                .Include(r => r.ApplicationUser)
                .Include(r => r.Machinery)
                .Include(r => r.TypeofRepair)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (requestRepair == null)
            {
                return NotFound();
            }

            return View(requestRepair);
        }

        // GET: RequestRepairs/Create
        public IActionResult Create()
        {
            ViewData["ApplicantID_FK"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle");
            ViewData["UserID_FK"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["MachineryID_FK"] = new SelectList(_context.Machineries, "ID", "MachineryTitle");
            ViewData["TypeofRepairID_FK"] = new SelectList(_context.TypeofRepairs, "ID", "TypeTitle");
            return View();
        }

        // POST: RequestRepairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Registered,IsActive,IsDelete,MachineryID_FK,UserID_FK,RequestDataTime,TypeofRepairID_FK,ApplicantID_FK,RequestTitle")] RequestRepair requestRepair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestRepair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantID_FK"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle", requestRepair.ApplicantID_FK);
            ViewData["UserID_FK"] = new SelectList(_context.ApplicationUsers, "Id", "Id", requestRepair.UserID_FK);
            ViewData["MachineryID_FK"] = new SelectList(_context.Machineries, "ID", "MachineryTitle", requestRepair.MachineryID_FK);
            ViewData["TypeofRepairID_FK"] = new SelectList(_context.TypeofRepairs, "ID", "TypeTitle", requestRepair.TypeofRepairID_FK);
            return View(requestRepair);
        }

        // GET: RequestRepairs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestRepair = await _context.RequestRepairs.FindAsync(id);
            if (requestRepair == null)
            {
                return NotFound();
            }
            ViewData["ApplicantID_FK"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle", requestRepair.ApplicantID_FK);
            ViewData["UserID_FK"] = new SelectList(_context.ApplicationUsers, "Id", "Id", requestRepair.UserID_FK);
            ViewData["MachineryID_FK"] = new SelectList(_context.Machineries, "ID", "MachineryTitle", requestRepair.MachineryID_FK);
            ViewData["TypeofRepairID_FK"] = new SelectList(_context.TypeofRepairs, "ID", "TypeTitle", requestRepair.TypeofRepairID_FK);
            return View(requestRepair);
        }

        // POST: RequestRepairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,Registered,IsActive,IsDelete,MachineryID_FK,UserID_FK,RequestDataTime,TypeofRepairID_FK,ApplicantID_FK,RequestTitle")] RequestRepair requestRepair)
        {
            if (id != requestRepair.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestRepair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestRepairExists(requestRepair.ID))
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
            ViewData["ApplicantID_FK"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle", requestRepair.ApplicantID_FK);
            ViewData["UserID_FK"] = new SelectList(_context.ApplicationUsers, "Id", "Id", requestRepair.UserID_FK);
            ViewData["MachineryID_FK"] = new SelectList(_context.Machineries, "ID", "MachineryTitle", requestRepair.MachineryID_FK);
            ViewData["TypeofRepairID_FK"] = new SelectList(_context.TypeofRepairs, "ID", "TypeTitle", requestRepair.TypeofRepairID_FK);
            return View(requestRepair);
        }

        // GET: RequestRepairs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestRepair = await _context.RequestRepairs
                .Include(r => r.Applicant)
                .Include(r => r.ApplicationUser)
                .Include(r => r.Machinery)
                .Include(r => r.TypeofRepair)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (requestRepair == null)
            {
                return NotFound();
            }

            return View(requestRepair);
        }

        // POST: RequestRepairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var requestRepair = await _context.RequestRepairs.FindAsync(id);
            _context.RequestRepairs.Remove(requestRepair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestRepairExists(long id)
        {
            return _context.RequestRepairs.Any(e => e.ID == id);
        }
    }
}

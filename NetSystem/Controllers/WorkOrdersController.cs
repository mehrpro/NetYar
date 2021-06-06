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
    public class WorkOrdersController : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrders
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WorkOrders.Include(w => w.RequestRepair);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WorkOrders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders
                .Include(w => w.RequestRepair)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public IActionResult Create()
        {
            ViewData["RequestID_FK"] = new SelectList(_context.RequestRepairs, "ID", "RequestTitle");
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IsActive,IsDelete,RequestID_FK,Electrical,Mecanical,Piping,Creating,Equip,RepairOutside,RepairOutSideReportID_FK,StartWorking,Cause_Exhaustion,Cause_OperatorNegligence,Cause_QualityofSpareParts,Cause_RepairmanError,OtherError,OtherErrorDescription,ReportRepair,PersonHours,PersonHoursTime,PersonHoursDescription,ProductionPlanning,ProductionPlanningTime,ProductionPlanningDescription,NoSpareParts,NoSparePartsTime,NoSparePartsDescription,Other,OtherTime,OtherDescription,CloseRequest,DateTimeClosing")] WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RequestID_FK"] = new SelectList(_context.RequestRepairs, "ID", "RequestTitle", workOrder.RequestID_FK);
            return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders.FindAsync(id);
            if (workOrder == null)
            {
                return NotFound();
            }
            ViewData["RequestID_FK"] = new SelectList(_context.RequestRepairs, "ID", "RequestTitle", workOrder.RequestID_FK);
            return View(workOrder);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,IsActive,IsDelete,RequestID_FK,Electrical,Mecanical,Piping,Creating,Equip,RepairOutside,RepairOutSideReportID_FK,StartWorking,Cause_Exhaustion,Cause_OperatorNegligence,Cause_QualityofSpareParts,Cause_RepairmanError,OtherError,OtherErrorDescription,ReportRepair,PersonHours,PersonHoursTime,PersonHoursDescription,ProductionPlanning,ProductionPlanningTime,ProductionPlanningDescription,NoSpareParts,NoSparePartsTime,NoSparePartsDescription,Other,OtherTime,OtherDescription,CloseRequest,DateTimeClosing")] WorkOrder workOrder)
        {
            if (id != workOrder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderExists(workOrder.ID))
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
            ViewData["RequestID_FK"] = new SelectList(_context.RequestRepairs, "ID", "RequestTitle", workOrder.RequestID_FK);
            return View(workOrder);
        }

        // GET: WorkOrders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrder = await _context.WorkOrders
                .Include(w => w.RequestRepair)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (workOrder == null)
            {
                return NotFound();
            }

            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var workOrder = await _context.WorkOrders.FindAsync(id);
            _context.WorkOrders.Remove(workOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderExists(long id)
        {
            return _context.WorkOrders.Any(e => e.ID == id);
        }
    }
}

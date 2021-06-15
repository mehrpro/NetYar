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
using NetSystem.Repositories;
using NetSystem.ViewModels.RequestRepair;

namespace NetSystem.Controllers
{
    public class WorkOrdersController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRequestRepairRepository _repairRepository;

        public WorkOrdersController(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            IRequestRepairRepository repairRepository)
        {
            _context = context;
            _userManager = userManager;
            _repairRepository = repairRepository;
        }

        // GET: WorkOrders
        public async Task<IActionResult> Index()
        {
            return View(await _repairRepository.GetActiveRequestRepair());
        }

        // GET: WorkOrders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();
            var result = await _repairRepository.GetRequestRepairById((long)id);
            if (result == null) return NotFound();
            ViewData["TypeofRepairList"] = new SelectList(_context.TypeofRepairs, "ID", "TypeTitle", result.TypeofRepairList);
            ViewData["ApplicantList"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle", result.ApplicantList);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(long id, [Bind("ID,TypeofRepairList,ApplicantList,RequestTitle")] RequestReapirDetailsViewModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (!await _repairRepository.UpdateRequestRepair(model))
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeofRepairList"] = new SelectList(_context.TypeofRepairs, "ID", "TypeTitle", model.TypeofRepairList);
            ViewData["ApplicantList"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle", model.ApplicantList);

            return View(model);
        }

        // GET: WorkOrders/Create
        public IActionResult Create(long RequestID)
        {
            ViewData["RequestID"] = RequestID;
            
            return View();
        }


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
                    
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RequestID_FK"] = new SelectList(_context.RequestRepairs, "ID", "RequestTitle", workOrder.RequestID_FK);
            return View(workOrder);
        }

        // GET: RequestRepairs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();
            var result = await _repairRepository.GetRequestRepairForDelete((long)id);
            if (result == null) return NotFound();
            return View(result);
        }

        // POST: RequestRepairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var requestRepair = await _context.RequestRepairs.FindAsync(id);
            requestRepair.IsDelete = true;
            requestRepair.IsActive = false;
            requestRepair.UserID_FK = _userManager.GetUserId(HttpContext.User);
            _context.RequestRepairs.Update(requestRepair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

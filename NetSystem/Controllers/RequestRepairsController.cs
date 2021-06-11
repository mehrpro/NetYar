using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetSystem.Entity;
using NetSystem.Models;
using NetSystem.Repositories;
using NetSystem.ViewModels;
using NetSystem.ViewModels.RequestRepair;

namespace NetSystem.Controllers
{
    [Authorize]
    public class RequestRepairsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRequestRepairRepository _repairRepository;


        public RequestRepairsController(
            AppDbContext context,
            UserManager<ApplicationUser> userManager,
            IRequestRepairRepository repairRepository)
        {
            _context = context;
            _userManager = userManager;
            _repairRepository = repairRepository;
        }

        // GET: RequestRepairs
        public async Task<IActionResult> Index()
        {
            return View(await _repairRepository.GetActiveRequestRepair());
        }

        // GET: RequestRepairs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null) return NotFound();
            var result = await _repairRepository.GetRequestRepairById((long)id);
            if (result == null) return NotFound();
            ViewData["TypeofRepairList"] = new SelectList(_context.TypeofRepairs, "ID", "TypeTitle", result.TypeofRepairList);
            ViewData["ApplicantList"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle", result.ApplicantList);

            return View(result);
        }

        // GET: RequestRepairs/Create
        public IActionResult Create()
        {
            ViewData["ApplicantID_FK"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle");
            ViewData["MachineryID_FK"] = new SelectList(_context.Machineries, "ID", "MachineryTitle");
            ViewData["TypeofRepairID_FK"] = new SelectList(_context.TypeofRepairs, "ID", "TypeTitle");
            return View();
        }

        // POST: RequestRepairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineryID_FK,RequestDataTimeMiladi,TypeofRepairID_FK,ApplicantID_FK,RequestTitle")] RequestRepairViewModel requestRepair)
        {


            if (ModelState.IsValid)
            {
                RequestRepair newRequestRepair = new RequestRepair()
                {
                    ApplicantID_FK = requestRepair.ApplicantID_FK,
                    IsActive = true,
                    IsDelete = false,
                    MachineryID_FK = requestRepair.MachineryID_FK,
                    Registered = DateTime.Now,
                    RequestDataTime = requestRepair.RequestDataTimeMiladi,
                    TypeofRepairID_FK = requestRepair.TypeofRepairID_FK,
                    RequestTitle = requestRepair.RequestTitle,
                    UserID_FK = _userManager.GetUserId(HttpContext.User)
                };
                await _context.RequestRepairs.AddAsync(newRequestRepair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantID_FK"] = new SelectList(_context.Applicants, "ID", "ApplicantTitle", requestRepair.ApplicantID_FK);
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

        // GET: RequestRepairs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();
            var result = await _repairRepository.GetRequestRepairForDeltet((long)id);
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
            requestRepair.UserID_FK =  _userManager.GetUserId(HttpContext.User);
            _context.RequestRepairs.Update(requestRepair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestRepairExists(long id)
        {
            return _context.RequestRepairs.Any(e => e.ID == id);
        }
    }
}

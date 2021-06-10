using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetSystem.Entity;
using NetSystem.Models;
using NetSystem.ViewModels.RequestRepair;

namespace NetSystem.Repositories
{
    public interface IRequestRepairRepository : IDisposable
    {
        /// <summary>
        /// لیست درخواست های فعال
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RequestRepairListViewModel>> GetActiveRequestRepair();

        Task<RequestReapirDetailsViewModel> GetRequestRepairById(long ld);
    }

    public class RequestRepairRepository : IRequestRepairRepository
    {
        private readonly AppDbContext _context;

        public UserManager<ApplicationUser> _userManager { get; }

        public RequestRepairRepository(AppDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IEnumerable<RequestRepairListViewModel>> GetActiveRequestRepair()
        {
            var reqList = await _context.RequestRepairs.Where(x => x.IsActive == true && x.IsDelete == false)
                .Include(x => x.Machinery).Include(x => x.TypeofRepair).ToListAsync();
            var result = new List<RequestRepairListViewModel>();
            foreach (var model in reqList)
            {
                result.Add(new RequestRepairListViewModel
                {
                    ID = model.ID,
                    RequestDataTime = model.RequestDataTime.PersianShortDate(),
                    MachineryCode = model.Machinery.Coding.Code.ToString(),
                    MachineryTitel = model.Machinery.MachineryTitle,
                    TypeofRepairID_FK = model.TypeofRepair.TypeTitle,
                    RequestTitle = model.RequestTitle
                });
            }

            return result;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<RequestReapirDetailsViewModel> GetRequestRepairById(long ld)
        {
            var req = await   _context.RequestRepairs.Where(x => x.ID == ld).Include(u=>u.ApplicationUser).Include(w=>w.Machinery).Include(x => x.ApplicationUser).Include(x => x.Applicant).Include(x => x.TypeofRepair).ToListAsync();
            
            if (req.Count == 1)
            {
                var user = await _userManager.FindByIdAsync(req[0].UserID_FK);
                var result = new RequestReapirDetailsViewModel()
                {
                    ID = req[0].ID,
                    ApplicantList = req[0].ApplicantID_FK,
                    ApplicantUser = user.UserName,
                    MachineryCode = req[0].Machinery.Coding.ToString(),
                    MachineryTitel = req[0].Machinery.MachineryTitle,
                    RegisteredDataTime = req[0].Registered.PersianShortDate(),
                    RequestDataTime = req[0].RequestDataTime.PersianShortDate(),
                    RequestTitle = req[0].RequestTitle,
                    TypeofRepairList = req[0].TypeofRepairID_FK,


                };
                return result;
            }
            return null;
        }
    }
}
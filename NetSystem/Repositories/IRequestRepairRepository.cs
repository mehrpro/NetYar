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
        /// <summary>
        /// جزئیات درخواست براساس شناسه
        /// </summary>
        /// <param name="ld">شناسه</param>
        /// <returns></returns>
        Task<RequestReapirDetailsViewModel> GetRequestRepairById(long ld);
        /// <summary>
        /// ویرایش درخواست تعمیر
        /// </summary>
        /// <param name="model">مدل</param>
        /// <returns></returns>
        Task<bool> UpdateRequestRepair(RequestReapirDetailsViewModel model);
        /// <summary>
        /// جزئیات درخواست برای صفحه حذف
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <returns></returns>
        Task<RequestRepairDeleteViewModel> GetRequestRepairForDeltet(long id);
    }

    public class RequestRepairRepository : IRequestRepairRepository
    {
        private readonly AppDbContext _context;

        public UserManager<ApplicationUser> _userManager { get; }

        public RequestRepairRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IEnumerable<RequestRepairListViewModel>> GetActiveRequestRepair()
        {
            var reqList = await _context.RequestRepairs.Where(x => x.IsActive == true && x.IsDelete == false)
                .Include(x => x.Machinery).Include(x => x.Machinery.Coding).Include(x => x.TypeofRepair).ToListAsync();
            if (reqList.Count > 0)
            {
                var result = new List<RequestRepairListViewModel>();
                foreach (var model in reqList)
                {
                    var item = new RequestRepairListViewModel();
                    item.RequestDataTime = model.RequestDataTime.PersianShortDate();
                    item.MachineryCode = model.Machinery.Coding.Code.ToString();
                    item.MachineryTitel = model.Machinery.MachineryTitle;
                    item.TypeofRepairID_FK = model.TypeofRepair.TypeTitle;
                    item.RequestTitle = model.RequestTitle;
                    item.ID = model.ID;
                    result.Add(item);
                }

                return result;
            }
            return null;

        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<RequestReapirDetailsViewModel> GetRequestRepairById(long ld)
        {
            var req = await _context.RequestRepairs.Where(x => x.ID == ld)
                .Include(u => u.ApplicationUser)
                .Include(x => x.Machinery.Coding)
                .Include(w => w.Machinery)
                .ToListAsync();

            if (req.Count == 1)
            {
                var user = await _userManager.FindByIdAsync(req[0].UserID_FK);
                var result = new RequestReapirDetailsViewModel();
                result.ID = req[0].ID;
                result.ApplicantList = req[0].ApplicantID_FK;
                result.ApplicantUser = user.UserName;
                result.MachineryCode = req[0].Machinery.Coding.Code.ToString();
                result.MachineryTitel = req[0].Machinery.MachineryTitle;
                result.RegisteredDataTime = req[0].Registered.PersianShortDate();
                result.RequestDataTime = req[0].RequestDataTime.PersianShortDate();
                result.RequestTitle = req[0].RequestTitle;
                result.TypeofRepairList = req[0].TypeofRepairID_FK;
                return result;
            }
            return null;
        }

        public async Task<bool> UpdateRequestRepair(RequestReapirDetailsViewModel model)
        {
            try
            {
                var req = await _context.RequestRepairs.FindAsync(model.ID);
                req.ApplicantID_FK = model.ApplicantList;
                req.TypeofRepairID_FK = model.TypeofRepairList;
                req.RequestTitle = model.RequestTitle.Trim();
                _context.Update(req);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public async Task<RequestRepairDeleteViewModel> GetRequestRepairForDeltet(long id)
        {
            var req = await _context.RequestRepairs.Where(x => x.ID == id)
              .Include(u => u.ApplicationUser)
              .Include(x => x.Machinery.Coding)
              .Include(w => w.Machinery)
              .Include(w=>w.TypeofRepair)
              .Include(e=>e.Applicant)
              .ToListAsync();

            if (req.Count == 1)
            {
                var user = await _userManager.FindByIdAsync(req[0].UserID_FK);
                var result = new RequestRepairDeleteViewModel();
                result.ID = req[0].ID;
                result.ApplicantList = req[0].Applicant.ApplicantTitle;
                result.ApplicantUser = user.UserName;
                result.MachineryCode = req[0].Machinery.Coding.Code.ToString();
                result.MachineryTitel = req[0].Machinery.MachineryTitle;
                result.RegisteredDataTime = req[0].Registered.PersianShortDate();
                result.RequestDataTime = req[0].RequestDataTime.PersianShortDate();
                result.RequestTitle = req[0].RequestTitle;
                result.TypeofRepairList = req[0].TypeofRepair.TypeTitle;
                return result;
            }
            return null;
        }
    }
}
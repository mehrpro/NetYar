using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
    }

    public class RequestRepairRepository : IRequestRepairRepository
    {
        private readonly AppDbContext _context;

        public RequestRepairRepository(AppDbContext context)
        {
            _context = context;
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
    }
}
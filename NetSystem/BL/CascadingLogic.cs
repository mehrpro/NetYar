using NetSystem.Entity;
using NetSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetSystem.BL
{
    public interface ICascadingLogic
    {
        List<Company> BindCompany();
        List<Group> BindGroup(int companyId);
        List<SubGroup> BindSubGroup(int groupId);
    }

    public class CascadingLogic : ICascadingLogic
    {
        protected readonly AppDbContext _context;

        public CascadingLogic(AppDbContext context)
        {
            _context = context;
        }

        public List<Company> BindCompany()
        {


            List<Company> lstCountry = new List<Company>();
            try
            {
                lstCountry = _context.Companies.ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstCountry;
        }

        public List<Group> BindGroup(int companyId)
        {
            List<Group> lstState = new List<Group>();
            try
            {


                lstState = _context.Groups.Where(a => a.CompanyID_FK == companyId).ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstState;
        }

        public List<SubGroup> BindSubGroup(int groupId)
        {
            List<SubGroup> lstCity = new List<SubGroup>();
            try
            {

                lstCity = _context.SubGroups.Where(a => a.GroupID_FK == groupId).ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstCity;
        }
    }
}

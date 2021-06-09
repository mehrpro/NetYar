using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetSystem.ViewModels.RequestRepair
{
    public class RequestRepairListViewModel
    {


        [Display(Name = "کد دستگاه")]
        public int MachineryID_FK { get; set; }

        [Display(Name = "تاریخ درخواست")]
        public DateTime RequestDataTime { get; set; }
        public DateTime RequestDataTimeMiladi { get; set; }

        [Display(Name = "نوع درخواست")]
        public int TypeofRepairID_FK { get; set; }

        [Display(Name = "واحد")]
        public int ApplicantID_FK { get; set; }

        [Display(Name = "شرح درخواست")]
        public string RequestTitle { get; set; }
    }
}

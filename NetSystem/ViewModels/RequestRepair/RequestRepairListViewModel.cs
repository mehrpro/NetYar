using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetSystem.ViewModels.RequestRepair
{
    public class RequestRepairListViewModel
    {


        [Display(AutoGenerateField = false)]
        public long ID { get; set; }
        [Display(Name = "تاریخ درخواست")]
        public string RequestDataTime { get; set; }
        [Display(Name = "کد دستگاه")]
        public string MachineryCode { get; set; }
        [Display(Name = "دستگاه")]
        public string MachineryTitel { get; set; }
        [Display(Name = "نوع درخواست")]
        public string TypeofRepairID_FK { get; set; }
        [Display(Name = "شرح درخواست")]
        public string RequestTitle { get; set; }
    }
}

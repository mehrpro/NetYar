using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetSystem.ViewModels.RequestRepair
{
    /// <summary>
    /// جزئیات درخواست
    /// </summary>
    public class RequestReapirDetailsViewModel
    {
        [Display(Name = "شماره درخواست")]
        public long ID { get; set; }
        [Display(Name = "تاریخ ثبت")]
        public string RegisteredDataTime { get; set; }
        [Display(Name = "تاریخ درخواست")]
        public string RequestDataTime { get; set; }
        [Display(Name = "کد دستگاه")]
        public string MachineryCode { get; set; }
        [Display(Name = "دستگاه")]
        public string MachineryTitel { get; set; }
        [Display(Name = "نوع درخواست")]
        public int TypeofRepairList { get; set; }
        [Display(Name = "شرح درخواست")]
        public string RequestTitle { get; set; }
        [Display(Name = "درخواست کننده")]
        public string ApplicantUser { get; set; }
        [Display(Name = "واحد درخواست کننده")]
        public int ApplicantList { get; set; }

    }
}

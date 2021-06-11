using System.ComponentModel.DataAnnotations;

namespace NetSystem.ViewModels.RequestRepair
{
    public class RequestRepairDeleteViewModel
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
        public string TypeofRepairList { get; set; }
        [Display(Name = "شرح درخواست")]
        public string RequestTitle { get; set; }
        [Display(Name = "درخواست کننده")]
        public string ApplicantUser { get; set; }
        [Display(Name = "واحد درخواست کننده")]
        public string ApplicantList { get; set; }
    }
}

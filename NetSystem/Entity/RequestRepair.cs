using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetSystem.Entity;

namespace NetSystem.Entity
{
    /// <summary>
    /// درخواست تعمیر
    /// </summary>
    public class RequestRepair
    {

        public RequestRepair()
        {
            ConsumableParts = new List<ConsumablePart>();
            WorkOrders = new List<WorkOrder>();

        }

        [Display(Name ="شناسه")]
        public long ID { get; set; }
        [Display(Name ="تاریخ ثبت")]
        public DateTime Registered { get; set; }
        [Display(Name ="وضعیت جاری")]
        public bool IsActive { get; set; }
        [Display(Name ="باطل شده")]
        public bool IsDelete { get; set; }
        [Display(Name ="کد دستگاه")]
        public int MachineryID_FK { get; set; }
        [Display(Name ="کد دستگاه")]
        public Machinery Machinery { get; set; }
        [Display(Name ="درخواست کننده")]
        public string UserID_FK { get; set; }
        [Display(Name ="درخواست کننده")]
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name ="تاریخ درخواست")]
        public DateTime RequestDataTime { get; set; }
        [Display(Name ="نوع درخواست")]
        public int TypeofRepairID_FK { get; set; }
        [Display(Name ="نوع درخواست")]
        public TypeofRepair TypeofRepair { get; set; }
        [Display(Name ="واحد")]
        public int ApplicantID_FK { get; set; }
        [Display(Name ="واحد")]
        public Applicant Applicant { get; set; }
        [Display(Name ="شرح درخواست")]
        public string RequestTitle { get; set; }

        public virtual ICollection<ConsumablePart> ConsumableParts { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }






    }
}
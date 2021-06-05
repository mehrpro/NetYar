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

        public long ID { get; set; }
        public DateTime Registered { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int MachineryID_FK { get; set; }
        public Machinery Machinery { get; set; }
        public string UserID_FK { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime RequestDataTime { get; set; }
        public int TypeofRepairID_FK { get; set; }
        public TypeofRepair TypeofRepair { get; set; }
        public int ApplicantID_FK { get; set; }
        public Applicant Applicant { get; set; }
        public string RequestTitle { get; set; }

        public virtual ICollection<ConsumablePart> ConsumableParts { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }






    }
}
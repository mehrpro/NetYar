using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetSystem.Entity
{
    public class TypeofRepair
    {
        public TypeofRepair()
        {
            RequestRepairs = new HashSet<RequestRepair>();
        }
        [Display(Name = "شناسه")]
        public int ID { get; set; }
        [Display(Name = "نوع")]
        public string TypeTitle { get; set; }


        public virtual ICollection<RequestRepair> RequestRepairs { get; set; }
    }
}

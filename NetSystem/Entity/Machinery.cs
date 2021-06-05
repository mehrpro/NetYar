using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSystem.Entity
{

    /// <summary>
    /// لیست ماشین آلات
    /// </summary>
    public class Machinery
    {
        public Machinery()
        {
            RequestRepairs = new HashSet<RequestRepair>();
        }
        [Display(Name = "شناسه")]
        public int ID { get; set; }
        [Display(Name = "قابلیت بهره برداری")]
        public bool IsActive { get; set; }
        [Display(Name = "از رده خارج")]
        public bool IsDelete { get; set; }
        [Display(Name = "کد تجهیز")]
        public long CodeID_FK { get; set; }
        [Display(Name = "کد تجهیز")]
        public Coding Coding { get; set; }
        [Display(Name = "عنوان تجهیز")]
        public string MachineryTitle { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }



        public virtual ICollection<RequestRepair> RequestRepairs { get; set; }

    }
}

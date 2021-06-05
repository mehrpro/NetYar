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
    /// کدینگ ماشین آلات
    /// </summary>
    public class Coding
    {
        public Coding()
        {
            Machineries = new List<Machinery>();
        }
        [Display(Name = "شناسه")]
        public long ID { get; set; }
        [Display(Name = "شرکت")]
        public int CompanyID_FK { get; set; }
        [Display(Name = "شرکت")]
        public Company Company { get; set; }
        [Display(Name = "گروه اصلی")]
        public int GroupID_FK { get; set; }
        [Display(Name = "گروه اصلی")]
        public Group Group { get; set; }
        [Display(Name = "گروه فرعی")]
        public int SubGroupID_FK { get; set; }
        [Display(Name = "گروه فرعی")]
        public SubGroup SubGroup { get; set; }

        public string UserID_FK { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "شمارنده")]
        public short CodeIndex { get; set; }
        [Display(Name = "کد")]
        public int Code { get; set; }
        [Display(Name = "عنوان")]
        public string CodeTitle { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }



        public virtual ICollection<Machinery> Machineries { get; set; }
    }
}

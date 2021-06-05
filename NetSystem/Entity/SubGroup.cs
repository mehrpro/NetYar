using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetSystem.Entity
{
    public class SubGroup
    {
        public SubGroup()
        {

            this.Codings = new HashSet<Coding>();
        }
        [Display(Name = "شناسه")]
        public int ID { get; set; }
        [Display(Name = "شرکت")]
        public int CompanyID_FK { get; set; }
        [Display(Name = "شرکت")]
        public Company Company { get; set; }
        [Display(Name = "گروه اصلی")]
        public int GroupID_FK { get; set; }
        [Display(Name = "گروه اصلی")]
        public Group Group { get; set; }
        [Display(Name = "کد گروه فرعی")]
        public byte SubGroupIndex { get; set; }
        [Display(Name = "گروه فرعی")]
        public string SubGroupTitle { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        public virtual ICollection<Coding> Codings { get; set; }
    }
}

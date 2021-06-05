using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetSystem.Entity
{
    public class Group
    {
        public Group()
        {



            this.SubGroups = new HashSet<SubGroup>();
            this.Codings = new HashSet<Coding>();
        }
        [Display(Name = "شناسه")]
        public int ID { get; set; }
        [Display(Name = "شرکت")]
        public int CompanyID_FK { get; set; }
        [Display(Name = "شرکت")]
        public Company Company { get; set; }
        [Display(Name = "کد گروه")]
        public byte GroupIndex { get; set; }
        [Display(Name = "عنوان گروه")]
        public string GroupTitle { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        public virtual ICollection<SubGroup> SubGroups { get; set; }
        public virtual ICollection<Coding> Codings { get; set; }
    }
}

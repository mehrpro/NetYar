using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace NetSystem.Entity
{
    /// <summary>
    /// واحد درخواست کننده
    /// </summary>
    public class Applicant
    {

        public Applicant()
        {
            RequestRepairs = new HashSet<RequestRepair>();

        }

        [Display(Name = "شناسه")]
        public int ID { get; set; }
        [Display(Name = "واحد درخواست کننده")]
        public string ApplicantTitle { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }


        public virtual ICollection<RequestRepair> RequestRepairs { get; set; }




    }
}

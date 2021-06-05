using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NetSystem.Entity
{
    /// <summary>
    /// کاربران
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            RequestRepairs = new HashSet<RequestRepair>();
            Codings = new HashSet<Coding>();
        }


        //[Required]
        //[MaxLength(250)]
        //public string FullName { get; set; }





        public virtual ICollection<RequestRepair> RequestRepairs { get; set; }
        public virtual ICollection<Coding> Codings { get; set; }
    }
}
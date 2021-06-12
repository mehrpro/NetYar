using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetSystem.ViewModels
{
    public class CascadingDropdownViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ForeignKeyId { get; set; }
    }
}

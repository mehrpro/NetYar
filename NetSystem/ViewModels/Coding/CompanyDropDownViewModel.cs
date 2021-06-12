using System.ComponentModel.DataAnnotations;

namespace NetSystem.ViewModels.Coding
{
    public class CompanyDropDownViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ForeignKeyId { get; set; }
    }
}

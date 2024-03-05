using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNet_Identity.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Degree { get; set; }
        [Column(TypeName ="money")]
        public decimal? Salary { get; set; }
        [ForeignKey("workDepartment")]
        [Display(Name ="Department")]
        public int? Dept_Id { get; set; }

        // Navigation Properties
        public List<Ins_Course> courses { get; set; }
        public Department workDepartment { get; set; }
        public Department mangeDepartment { get; set; }

        public ApplicationUser? Account { get; set; }

    }
}

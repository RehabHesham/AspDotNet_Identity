using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNet_Identity.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string?   Location { get; set;}
        [ForeignKey("manger")]
        public int? MangerId { get; set; }

        // Navigation Properties
        [InverseProperty("mangeDepartment")]
        public Instructor manger { get; set; }


        [InverseProperty("workDepartment")]
        public List<Instructor> instructors { get; set; }

        public List<Student> students { get; set; }
    }
}

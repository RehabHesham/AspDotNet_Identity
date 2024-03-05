using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNet_Identity.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        [ForeignKey("department")]
        public int? DeptId { get; set; }
        [ForeignKey("leader")]
        public int? LeaderId { get; set; }

        // Navigation Properties

        public List<Std_Course> courses { get; set; }
        public Department department { get; set; }


        public Student leader { get; set; }
        [InverseProperty("leader")]
        public List<Student> group { get; set; }
    }
}

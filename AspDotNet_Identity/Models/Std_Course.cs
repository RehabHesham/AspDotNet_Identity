using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNet_Identity.Models
{
    public class Std_Course
    {
        public int StdId { get; set; }
        public int CrsId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Grade { get; set; }

        // Navigation Properties
        [ForeignKey("StdId")]
        public Student student { get; set; }
        [ForeignKey("CrsId")]
        public Course course { get; set; }
    }
}

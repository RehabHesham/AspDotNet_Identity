namespace AspDotNet_Identity.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }

        // Navigation Properties
        public List<Std_Course> students { get; set; }
        public List<Ins_Course> instructors { get; set; }
    }
}

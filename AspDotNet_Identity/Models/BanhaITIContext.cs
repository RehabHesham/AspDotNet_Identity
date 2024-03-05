using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspDotNet_Identity.ViewModels;

namespace AspDotNet_Identity.Models
{
    public class BanhaITIContext : IdentityDbContext<ApplicationUser>
    {
        public BanhaITIContext(DbContextOptions<BanhaITIContext> options):base(options) { }

        public BanhaITIContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BanhaITI_identity;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composit primary key
            modelBuilder.Entity<Std_Course>().HasKey(sc => new {sc.StdId,sc.CrsId });

            // relation many to one in department
            //modelBuilder.Entity<Department>()
            //    .HasMany(d => d.instructors)
            //    .WithOne(i => i.workDepartment)
            //    .HasForeignKey(i => i.Dept_Id);

            // relation one to one in department
            //modelBuilder.Entity<Department>()
            //    .HasOne(d => d.manger)
            //    .WithOne(i => i.mangeDepartment)
            //    .HasForeignKey<Department>(d => d.MangerId);

            // self relation
            //modelBuilder.Entity<Student>()
            //    .HasMany(l => l.group)
            //    .WithOne(s => s.leader)
            //    .HasForeignKey(s => s.LeaderId);
   
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Ins_Course> Ins_Courses { get; set; }
        public DbSet<Std_Course> Std_Courses { get; set; }

    }
}

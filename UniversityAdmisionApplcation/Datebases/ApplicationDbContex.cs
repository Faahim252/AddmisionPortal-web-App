using Microsoft.EntityFrameworkCore;
using UniversityAdmisionApplcation.Models;

namespace UniversityAdmisionApplcation.Datebases
{
    public class ApplicationDbContex: DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
            : base(options)
        {
        }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<AdmissionOfficer> AdmissionOff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().ToTable("Registration");
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
            modelBuilder.Entity<EducationLevel>().ToTable("EducationLevel");
            modelBuilder.Entity<AdmissionOfficer>().ToTable("AdmissionOfficer");
        }

    }
}

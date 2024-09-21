using laba1.Models;
using laba1.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace laba1.Database
{

        public class MatlashDbContext : DbContext
        {
            DbSet<EducationalSubject> EducationalSubjects { get; set; }
            DbSet<Professor> Professors { get; set; }
            DbSet<Workload> Workloads { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration(new EducationSubjectConfiguration());
                modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
                modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
            }
            public MatlashDbContext(DbContextOptions<MatlashDbContext> options) : base(options)
            {
            }
        }
        public class MatlashDbContextFactory : IDesignTimeDbContextFactory<MatlashDbContext>
        {
            public MatlashDbContext CreateDbContext(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);
                var optionsBuilder = new DbContextOptionsBuilder<MatlashDbContext>();
                optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
                return new MatlashDbContext(optionsBuilder.Options);
            }
        }
}

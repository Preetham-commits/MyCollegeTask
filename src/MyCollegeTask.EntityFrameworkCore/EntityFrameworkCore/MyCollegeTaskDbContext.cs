using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCollegeTask.Authorization.Roles;
using MyCollegeTask.Authorization.Users;
using MyCollegeTask.MultiTenancy;
using MyCollegeTask.Modules;

namespace MyCollegeTask.EntityFrameworkCore
{
    public class MyCollegeTaskDbContext : AbpZeroDbContext<Tenant, Role, User, MyCollegeTaskDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyCollegeTaskDbContext(DbContextOptions<MyCollegeTaskDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Abp.Localization.ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760

            modelBuilder.Entity<Student>()
        .HasOne(s => s.College) // Student has one College
        .WithMany(c => c.Students) // College has many Students
        .HasForeignKey(s => s.CollegeId); // The foreign key in Student is CollegeId
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<College> College { get; set; }
    }
}

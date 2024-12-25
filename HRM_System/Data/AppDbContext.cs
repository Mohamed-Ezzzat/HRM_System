using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using HRM_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRM_System.Data
{
    public class AppDbContext : IdentityDbContext<HRUser>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<HRUser> HRUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkData> WorkDatas { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<SalaryData> salaryDatas { get; set; }
        public DbSet<Officialleavesettings> OfficialleaveSettings { get; set; }
        public DbSet<AttendanceAndDepartureofEmployees> AttendanceAndDepartureofEmployees { get; set; }
        //public DbSet<Usergroupsandpermissions> Usergroupsandpermissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HRUser>().Ignore(x => x.PhoneNumber);
            modelBuilder.Entity<HRUser>().Ignore(x => x.PhoneNumberConfirmed);

            modelBuilder.Entity<HRUser>()
                .HasOne(h => h.Admin)
                .WithOne(h => h.HRUser);

            modelBuilder.Entity<AttendanceAndDepartureofEmployees>()
                .Property(x => x.Extrahours).HasDefaultValue(0);

            modelBuilder.Entity<AttendanceAndDepartureofEmployees>()
                    .Property(x => x.Discounthours).HasDefaultValue(0);

        }

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}


    }
}

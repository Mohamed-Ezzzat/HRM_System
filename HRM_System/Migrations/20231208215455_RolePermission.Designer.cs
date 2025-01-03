﻿// <auto-generated />
using System;
using HRM_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRM_System.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231208215455_RolePermission")]
    partial class RolePermission
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HRM_System.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("HRM_System.Models.AttendanceAndDepartureofEmployees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("Check_outDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Check_outTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discounthours")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Extrahours")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Month")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeAttendance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkDataId")
                        .HasColumnType("int");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("WorkDataId");

                    b.ToTable("AttendanceAndDepartureofEmployees");
                });

            modelBuilder.Entity("HRM_System.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Deparment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HRM_System.Models.GeneralSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Additional")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("Thedayofthefirstofficialvacation")
                        .HasColumnType("int");

                    b.Property<int?>("Thesecondofficialvacationday")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GeneralSettings");
                });

            modelBuilder.Entity("HRM_System.Models.HRUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HRM_System.Models.Officialleavesettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("OfficialleaveSettings");
                });

            modelBuilder.Entity("HRM_System.Models.SalaryData", b =>
                {
                    b.Property<int>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Additional_hours")
                        .HasColumnType("int");

                    b.Property<int?>("AttendanceAndDepartureofEmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("Daysofabsence")
                        .HasColumnType("int");

                    b.Property<int>("Discount_per_hour")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ExtraTotal")
                        .HasColumnType("int");

                    b.Property<int?>("GeneralSettingsId")
                        .HasColumnType("int");

                    b.Property<int?>("OfficialleavesettingsId")
                        .HasColumnType("int");

                    b.Property<int>("RecordDays")
                        .HasColumnType("int");

                    b.Property<int>("TotalDiscount")
                        .HasColumnType("int");

                    b.Property<int?>("WorkDateId")
                        .HasColumnType("int");

                    b.HasKey("SalaryId");

                    b.HasIndex("AttendanceAndDepartureofEmployeesId")
                        .IsUnique()
                        .HasFilter("[AttendanceAndDepartureofEmployeesId] IS NOT NULL");

                    b.HasIndex("EmployeeId")
                        .IsUnique()
                        .HasFilter("[EmployeeId] IS NOT NULL");

                    b.HasIndex("GeneralSettingsId")
                        .IsUnique()
                        .HasFilter("[GeneralSettingsId] IS NOT NULL");

                    b.HasIndex("OfficialleavesettingsId")
                        .IsUnique()
                        .HasFilter("[OfficialleavesettingsId] IS NOT NULL");

                    b.HasIndex("WorkDateId")
                        .IsUnique()
                        .HasFilter("[WorkDateId] IS NOT NULL");

                    b.ToTable("salaryDatas");
                });

            modelBuilder.Entity("HRM_System.Models.WorkData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Attendance")
                        .HasColumnType("time");

                    b.Property<DateTime>("Dateofcontract")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Departure")
                        .HasColumnType("time");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("WorkDatas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HRM_System.Models.Admin", b =>
                {
                    b.HasOne("HRM_System.Models.HRUser", "HRUser")
                        .WithOne("Admin")
                        .HasForeignKey("HRM_System.Models.Admin", "UserId");

                    b.Navigation("HRUser");
                });

            modelBuilder.Entity("HRM_System.Models.AttendanceAndDepartureofEmployees", b =>
                {
                    b.HasOne("HRM_System.Models.Employee", "Employee")
                        .WithMany("AttendanceAndDepartureofEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM_System.Models.WorkData", "WorkData")
                        .WithMany()
                        .HasForeignKey("WorkDataId");

                    b.Navigation("Employee");

                    b.Navigation("WorkData");
                });

            modelBuilder.Entity("HRM_System.Models.Employee", b =>
                {
                    b.HasOne("HRM_System.Models.Admin", "Admin")
                        .WithMany("Employees")
                        .HasForeignKey("AdminId");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("HRM_System.Models.Officialleavesettings", b =>
                {
                    b.HasOne("HRM_System.Models.Admin", "Admin")
                        .WithMany("Officialleavesettings")
                        .HasForeignKey("AdminId");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("HRM_System.Models.SalaryData", b =>
                {
                    b.HasOne("HRM_System.Models.AttendanceAndDepartureofEmployees", "AttendanceAndDepartureofEmployees")
                        .WithOne("SalaryData")
                        .HasForeignKey("HRM_System.Models.SalaryData", "AttendanceAndDepartureofEmployeesId");

                    b.HasOne("HRM_System.Models.Employee", "Employee")
                        .WithOne("SalaryData")
                        .HasForeignKey("HRM_System.Models.SalaryData", "EmployeeId");

                    b.HasOne("HRM_System.Models.GeneralSettings", "GeneralSettings")
                        .WithOne("SalaryData")
                        .HasForeignKey("HRM_System.Models.SalaryData", "GeneralSettingsId");

                    b.HasOne("HRM_System.Models.Officialleavesettings", "Officialleavesettings")
                        .WithOne("SalaryData")
                        .HasForeignKey("HRM_System.Models.SalaryData", "OfficialleavesettingsId");

                    b.HasOne("HRM_System.Models.WorkData", "WorkData")
                        .WithOne("SalaryData")
                        .HasForeignKey("HRM_System.Models.SalaryData", "WorkDateId");

                    b.Navigation("AttendanceAndDepartureofEmployees");

                    b.Navigation("Employee");

                    b.Navigation("GeneralSettings");

                    b.Navigation("Officialleavesettings");

                    b.Navigation("WorkData");
                });

            modelBuilder.Entity("HRM_System.Models.WorkData", b =>
                {
                    b.HasOne("HRM_System.Models.Admin", "Admin")
                        .WithMany("workdatas")
                        .HasForeignKey("AdminId");

                    b.HasOne("HRM_System.Models.Employee", "Employee")
                        .WithOne("WorkData")
                        .HasForeignKey("HRM_System.Models.WorkData", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HRM_System.Models.HRUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HRM_System.Models.HRUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRM_System.Models.HRUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HRM_System.Models.HRUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HRM_System.Models.Admin", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Officialleavesettings");

                    b.Navigation("workdatas");
                });

            modelBuilder.Entity("HRM_System.Models.AttendanceAndDepartureofEmployees", b =>
                {
                    b.Navigation("SalaryData");
                });

            modelBuilder.Entity("HRM_System.Models.Employee", b =>
                {
                    b.Navigation("AttendanceAndDepartureofEmployees");

                    b.Navigation("SalaryData");

                    b.Navigation("WorkData");
                });

            modelBuilder.Entity("HRM_System.Models.GeneralSettings", b =>
                {
                    b.Navigation("SalaryData");
                });

            modelBuilder.Entity("HRM_System.Models.HRUser", b =>
                {
                    b.Navigation("Admin");
                });

            modelBuilder.Entity("HRM_System.Models.Officialleavesettings", b =>
                {
                    b.Navigation("SalaryData");
                });

            modelBuilder.Entity("HRM_System.Models.WorkData", b =>
                {
                    b.Navigation("SalaryData");
                });
#pragma warning restore 612, 618
        }
    }
}

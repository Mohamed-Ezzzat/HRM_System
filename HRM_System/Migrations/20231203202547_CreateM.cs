using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM_System.Migrations
{
    public partial class CreateM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Additional = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Thedayofthefirstofficialvacation = table.Column<int>(type: "int", nullable: false),
                    Thesecondofficialvacationday = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usergroupsandpermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permission_Employee_Create = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Employee_View = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Employee_Edit = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Employee_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Payroll_Create = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Payroll_View = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Payroll_Edit = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Payroll_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permission_GeneralSettings_Create = table.Column<bool>(type: "bit", nullable: false),
                    Permission_GeneralSettings_View = table.Column<bool>(type: "bit", nullable: false),
                    Permission_GeneralSettings_Edit = table.Column<bool>(type: "bit", nullable: false),
                    Permission_GeneralSettings_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Attendance_Create = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Attendance_View = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Attendance_Edit = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Attendance_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usergroupsandpermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsergroupsandpermissionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admins_Usergroupsandpermissions_UsergroupsandpermissionsId",
                        column: x => x.UsergroupsandpermissionsId,
                        principalTable: "Usergroupsandpermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deparment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NationalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true, defaultValue: 3)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OfficialleaveSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialleaveSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialleaveSettings_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WorkDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dateofcontract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Attendance = table.Column<TimeSpan>(type: "time", nullable: false),
                    Departure = table.Column<TimeSpan>(type: "time", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkDatas_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WorkDatas_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceAndDepartureofEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Check_outDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<int>(type: "int", nullable: false),
                    TimeAttendance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Check_outTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extrahours = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Discounthours = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    WorkDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceAndDepartureofEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceAndDepartureofEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceAndDepartureofEmployees_WorkDatas_WorkDataId",
                        column: x => x.WorkDataId,
                        principalTable: "WorkDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "salaryDatas",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDays = table.Column<int>(type: "int", nullable: false),
                    Daysofabsence = table.Column<int>(type: "int", nullable: false),
                    ExtraTotal = table.Column<int>(type: "int", nullable: false),
                    TotalDiscount = table.Column<int>(type: "int", nullable: false),
                    Additional_hours = table.Column<int>(type: "int", nullable: false),
                    Discount_per_hour = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    WorkDateId = table.Column<int>(type: "int", nullable: true),
                    GeneralSettingsId = table.Column<int>(type: "int", nullable: true),
                    OfficialleavesettingsId = table.Column<int>(type: "int", nullable: true),
                    AttendanceAndDepartureofEmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salaryDatas", x => x.SalaryId);
                    table.ForeignKey(
                        name: "FK_salaryDatas_AttendanceAndDepartureofEmployees_AttendanceAndDepartureofEmployeesId",
                        column: x => x.AttendanceAndDepartureofEmployeesId,
                        principalTable: "AttendanceAndDepartureofEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_salaryDatas_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_salaryDatas_GeneralSettings_GeneralSettingsId",
                        column: x => x.GeneralSettingsId,
                        principalTable: "GeneralSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_salaryDatas_OfficialleaveSettings_OfficialleavesettingsId",
                        column: x => x.OfficialleavesettingsId,
                        principalTable: "OfficialleaveSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_salaryDatas_WorkDatas_WorkDateId",
                        column: x => x.WorkDateId,
                        principalTable: "WorkDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UsergroupsandpermissionsId",
                table: "Admins",
                column: "UsergroupsandpermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceAndDepartureofEmployees_EmployeeId",
                table: "AttendanceAndDepartureofEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceAndDepartureofEmployees_WorkDataId",
                table: "AttendanceAndDepartureofEmployees",
                column: "WorkDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdminId",
                table: "Employees",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialleaveSettings_AdminId",
                table: "OfficialleaveSettings",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_salaryDatas_AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas",
                column: "AttendanceAndDepartureofEmployeesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_salaryDatas_EmployeeId",
                table: "salaryDatas",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_salaryDatas_GeneralSettingsId",
                table: "salaryDatas",
                column: "GeneralSettingsId",
                unique: true,
                filter: "[GeneralSettingsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_salaryDatas_OfficialleavesettingsId",
                table: "salaryDatas",
                column: "OfficialleavesettingsId",
                unique: true,
                filter: "[OfficialleavesettingsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_salaryDatas_WorkDateId",
                table: "salaryDatas",
                column: "WorkDateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkDatas_AdminId",
                table: "WorkDatas",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkDatas_EmployeeId",
                table: "WorkDatas",
                column: "EmployeeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "salaryDatas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AttendanceAndDepartureofEmployees");

            migrationBuilder.DropTable(
                name: "GeneralSettings");

            migrationBuilder.DropTable(
                name: "OfficialleaveSettings");

            migrationBuilder.DropTable(
                name: "WorkDatas");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Usergroupsandpermissions");
        }
    }
}

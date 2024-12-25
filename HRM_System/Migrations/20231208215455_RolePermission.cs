using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM_System.Migrations
{
    public partial class RolePermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Usergroupsandpermissions_UsergroupsandpermissionsId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficialleaveSettings_Admins_AdminId",
                table: "OfficialleaveSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_salaryDatas_AttendanceAndDepartureofEmployees_AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_salaryDatas_Employees_EmployeeId",
                table: "salaryDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_salaryDatas_WorkDatas_WorkDateId",
                table: "salaryDatas");

            migrationBuilder.DropTable(
                name: "Usergroupsandpermissions");

            migrationBuilder.DropIndex(
                name: "IX_salaryDatas_AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas");

            migrationBuilder.DropIndex(
                name: "IX_salaryDatas_EmployeeId",
                table: "salaryDatas");

            migrationBuilder.DropIndex(
                name: "IX_salaryDatas_WorkDateId",
                table: "salaryDatas");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UsergroupsandpermissionsId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "UsergroupsandpermissionsId",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "WorkDateId",
                table: "salaryDatas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "salaryDatas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "OfficialleaveSettings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_salaryDatas_AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas",
                column: "AttendanceAndDepartureofEmployeesId",
                unique: true,
                filter: "[AttendanceAndDepartureofEmployeesId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_salaryDatas_EmployeeId",
                table: "salaryDatas",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_salaryDatas_WorkDateId",
                table: "salaryDatas",
                column: "WorkDateId",
                unique: true,
                filter: "[WorkDateId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialleaveSettings_Admins_AdminId",
                table: "OfficialleaveSettings",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salaryDatas_AttendanceAndDepartureofEmployees_AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas",
                column: "AttendanceAndDepartureofEmployeesId",
                principalTable: "AttendanceAndDepartureofEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salaryDatas_Employees_EmployeeId",
                table: "salaryDatas",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_salaryDatas_WorkDatas_WorkDateId",
                table: "salaryDatas",
                column: "WorkDateId",
                principalTable: "WorkDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficialleaveSettings_Admins_AdminId",
                table: "OfficialleaveSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_salaryDatas_AttendanceAndDepartureofEmployees_AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_salaryDatas_Employees_EmployeeId",
                table: "salaryDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_salaryDatas_WorkDatas_WorkDateId",
                table: "salaryDatas");

            migrationBuilder.DropIndex(
                name: "IX_salaryDatas_AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas");

            migrationBuilder.DropIndex(
                name: "IX_salaryDatas_EmployeeId",
                table: "salaryDatas");

            migrationBuilder.DropIndex(
                name: "IX_salaryDatas_WorkDateId",
                table: "salaryDatas");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "WorkDateId",
                table: "salaryDatas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "salaryDatas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdminId",
                table: "OfficialleaveSettings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsergroupsandpermissionsId",
                table: "Admins",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usergroupsandpermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permission_Attendance_Create = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Attendance_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Attendance_Edit = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Attendance_View = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Employee_Create = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Employee_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Employee_Edit = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Employee_View = table.Column<bool>(type: "bit", nullable: false),
                    Permission_GeneralSettings_Create = table.Column<bool>(type: "bit", nullable: false),
                    Permission_GeneralSettings_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permission_GeneralSettings_Edit = table.Column<bool>(type: "bit", nullable: false),
                    Permission_GeneralSettings_View = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Payroll_Create = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Payroll_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Payroll_Edit = table.Column<bool>(type: "bit", nullable: false),
                    Permission_Payroll_View = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usergroupsandpermissions", x => x.Id);
                });

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
                name: "IX_salaryDatas_WorkDateId",
                table: "salaryDatas",
                column: "WorkDateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UsergroupsandpermissionsId",
                table: "Admins",
                column: "UsergroupsandpermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Usergroupsandpermissions_UsergroupsandpermissionsId",
                table: "Admins",
                column: "UsergroupsandpermissionsId",
                principalTable: "Usergroupsandpermissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialleaveSettings_Admins_AdminId",
                table: "OfficialleaveSettings",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salaryDatas_AttendanceAndDepartureofEmployees_AttendanceAndDepartureofEmployeesId",
                table: "salaryDatas",
                column: "AttendanceAndDepartureofEmployeesId",
                principalTable: "AttendanceAndDepartureofEmployees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salaryDatas_Employees_EmployeeId",
                table: "salaryDatas",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_salaryDatas_WorkDatas_WorkDateId",
                table: "salaryDatas",
                column: "WorkDateId",
                principalTable: "WorkDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

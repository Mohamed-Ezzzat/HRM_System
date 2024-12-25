using Microsoft.EntityFrameworkCore.Migrations;

namespace HRM_System.Migrations
{
    public partial class NewRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Admins_AdminId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficialleaveSettings_Admins_AdminId",
                table: "OfficialleaveSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkDatas_Admins_AdminId",
                table: "WorkDatas");

            migrationBuilder.DropIndex(
                name: "IX_WorkDatas_AdminId",
                table: "WorkDatas");

            migrationBuilder.DropIndex(
                name: "IX_OfficialleaveSettings_AdminId",
                table: "OfficialleaveSettings");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AdminId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "WorkDatas");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "OfficialleaveSettings");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "WorkDatas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "OfficialleaveSettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Employees",
                type: "int",
                nullable: true,
                defaultValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_WorkDatas_AdminId",
                table: "WorkDatas",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialleaveSettings_AdminId",
                table: "OfficialleaveSettings",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdminId",
                table: "Employees",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Admins_AdminId",
                table: "Employees",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialleaveSettings_Admins_AdminId",
                table: "OfficialleaveSettings",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkDatas_Admins_AdminId",
                table: "WorkDatas",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

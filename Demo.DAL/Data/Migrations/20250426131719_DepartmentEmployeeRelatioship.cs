using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentEmployeeRelatioship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Employeee",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Employeee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employeee_DepartmentId",
                table: "Employeee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeee_Departments_DepartmentId",
                table: "Employeee",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeee_Departments_DepartmentId",
                table: "Employeee");

            migrationBuilder.DropIndex(
                name: "IX_Employeee_DepartmentId",
                table: "Employeee");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Employeee");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Employeee",
                newName: "phoneNumber");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addColumnEmployeeImageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageName",
                table: "Employeee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageName",
                table: "Employeee");
        }
    }
}

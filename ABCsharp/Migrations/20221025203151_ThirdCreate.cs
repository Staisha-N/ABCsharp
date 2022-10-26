using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCsharp.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Importance",
                table: "Concepts",
                newName: "example");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "example",
                table: "Concepts",
                newName: "Importance");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCsharp.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "example",
                table: "Concepts");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Concepts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Concepts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "details",
                table: "Concepts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "details",
                table: "Concepts");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Concepts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Concepts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "example",
                table: "Concepts",
                type: "TEXT",
                nullable: true);
        }
    }
}

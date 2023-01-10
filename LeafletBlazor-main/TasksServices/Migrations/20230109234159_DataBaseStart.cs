using Microsoft.EntityFrameworkCore.Migrations;

namespace TasksServices.Migrations
{
    public partial class DataBaseStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Markers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Markers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slope1",
                table: "Markers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slope2",
                table: "Markers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slope3",
                table: "Markers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slope4",
                table: "Markers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Slope1",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Slope2",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Slope3",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "Slope4",
                table: "Markers");
        }
    }
}

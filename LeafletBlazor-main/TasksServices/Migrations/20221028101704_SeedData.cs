using Microsoft.EntityFrameworkCore.Migrations;

namespace TasksServices.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Markers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Markers",
                columns: new[] { "Id", "Alt", "Keyboard", "Latitude", "Longitude", "Opacity", "RiseOffset", "RiseOnHover", "Title", "ZIndexOffset" },
                values: new object[,]
                {
                    { 1, null, false, 46.4768747, 22.7541473, 0.0, 0, false, "Arieșeni", 0 },
                    { 2, null, false, 45.44273707, 25.58889896, 0.0, 0, false, "Azuga", 0 },
                    { 3, null, false, 47.661522, 23.6956528, 0.0, 0, false, "Baia Sprie", 0 },
                    { 4, null, false, 46.3502813, 25.4733735, 0.0, 0, false, "Băile Homorod", 0 },
                    { 5, null, false, 46.1556322, 25.8707339, 0.0, 0, false, "Băile Tușnad", 0 },
                    { 6, null, false, 46.5359435, 23.3098931, 0.0, 0, false, "Băișoara", 0 },
                    { 7, null, false, 45.6047439, 24.6171756, 0.0, 0, false, "Bâlea", 0 },
                    { 8, null, false, 47.6308945, 24.7407681, 0.0, 0, false, "Borșa", 0 },
                    { 9, null, false, 46.9782008, 25.5768737, 0.0, 0, false, "Borsec", 0 },
                    { 10, null, false, 45.5063162, 25.3771276, 0.0, 0, false, "Bran", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Markers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Markers",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

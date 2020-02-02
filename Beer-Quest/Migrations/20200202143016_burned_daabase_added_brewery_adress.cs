using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer_Quest.Migrations
{
    public partial class burned_daabase_added_brewery_adress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb882310-9f8b-4336-963e-e4bd202b2938", "AQAAAAEAACcQAAAAEOzYxxef3be5jopgleZcahs1n1gpjvKF1Q3UQiC76iXfYDEkwQMUFY5zMPQ3Q7CXiQ==" });

            migrationBuilder.UpdateData(
                table: "Brewery",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: "809 Ewing Ave");

            migrationBuilder.UpdateData(
                table: "Brewery",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: "505 Lea Ave, Nashville");

            migrationBuilder.UpdateData(
                table: "Brewery",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: "423 6th Ave S");

            migrationBuilder.UpdateData(
                table: "Brewery",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address",
                value: "701 8th Ave S");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cbde4b7f-db8b-4cce-a760-5e46e2f187d6", "AQAAAAEAACcQAAAAEBNRzxwZdKl6dsDPeyb6aZH/mbBo1FNiq852lftRFdtfuCBc+ziWoC8IvWaBtgq5hg==" });

            migrationBuilder.UpdateData(
                table: "Brewery",
                keyColumn: "Id",
                keyValue: 1,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brewery",
                keyColumn: "Id",
                keyValue: 2,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brewery",
                keyColumn: "Id",
                keyValue: 3,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brewery",
                keyColumn: "Id",
                keyValue: 4,
                column: "Address",
                value: null);
        }
    }
}

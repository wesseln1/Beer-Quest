using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer_Quest.Migrations
{
    public partial class addedrinktype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db5d0cc2-c142-4ebe-adef-9ebb9bfc11c7", "AQAAAAEAACcQAAAAEO7VBP+sWKHXQK/kV89q6vf6hMkWprd9gltv7ViQ4tMbPyet8gFNQjoKJ0ll5Esafw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_DrinkTypeId",
                table: "Drink",
                column: "DrinkTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_DrinkType_DrinkTypeId",
                table: "Drink",
                column: "DrinkTypeId",
                principalTable: "DrinkType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_DrinkType_DrinkTypeId",
                table: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_Drink_DrinkTypeId",
                table: "Drink");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e05773ae-afa9-4c35-a21f-a69c658dde27", "AQAAAAEAACcQAAAAEItDqxT0F9G6wpEPplUY0rbtpeqsejU2oynZualaZYuGIkqB5Qkt/H8fM+Cuphar7g==" });
        }
    }
}

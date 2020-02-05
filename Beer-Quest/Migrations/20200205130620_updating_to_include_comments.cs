using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer_Quest.Migrations
{
    public partial class updating_to_include_comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comment",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5817a0b7-1421-45c0-9cd3-af976e88a062", "AQAAAAEAACcQAAAAEFB+w8pg0U0vhk78+1Z4JiGbnIDitQgpAxHbd96vrm2tHfUk2l2SNz2fukO6FcF5Fw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_BreweryId",
                table: "Comment",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cheer_BreweryId",
                table: "Cheer",
                column: "BreweryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheer_Brewery_BreweryId",
                table: "Cheer",
                column: "BreweryId",
                principalTable: "Brewery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Brewery_BreweryId",
                table: "Comment",
                column: "BreweryId",
                principalTable: "Brewery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheer_Brewery_BreweryId",
                table: "Cheer");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Brewery_BreweryId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_BreweryId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Cheer_BreweryId",
                table: "Cheer");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65f52021-8a02-4d3d-97a5-8a9f8958596a", "AQAAAAEAACcQAAAAEK0QZh4Fy3QigTBr6AgivOtKZXsi2aYFxzxr/f9WS7utDx63FADiYqA0LfqGJsvnTg==" });
        }
    }
}

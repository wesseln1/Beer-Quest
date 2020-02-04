using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer_Quest.Migrations
{
    public partial class changed_cheersUserId_toString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Cheer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65f52021-8a02-4d3d-97a5-8a9f8958596a", "AQAAAAEAACcQAAAAEK0QZh4Fy3QigTBr6AgivOtKZXsi2aYFxzxr/f9WS7utDx63FADiYqA0LfqGJsvnTg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Cheer",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7bf73c7-c835-417f-8103-425af7abd38f", "AQAAAAEAACcQAAAAENXUNKqoJE084GE6OV3xI4JpmlFqhCkK34bO7IpRTzd0it0GAFJ2QLTvjLQ0U5i+SQ==" });
        }
    }
}

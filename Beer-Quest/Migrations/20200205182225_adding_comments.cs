using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer_Quest.Migrations
{
    public partial class adding_comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3bde06fa-8bfd-415d-9727-89f8111f5ab0", "AQAAAAEAACcQAAAAEMqxkYHw2MfSa4al+fdu7KV9axv+ag0TdpMfp1j/Lq1w2c6OnVUTQEdaQrCv8t97Uw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5817a0b7-1421-45c0-9cd3-af976e88a062", "AQAAAAEAACcQAAAAEFB+w8pg0U0vhk78+1Z4JiGbnIDitQgpAxHbd96vrm2tHfUk2l2SNz2fukO6FcF5Fw==" });
        }
    }
}

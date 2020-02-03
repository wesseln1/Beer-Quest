using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer_Quest.Migrations
{
    public partial class updateDatabase_phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7bf73c7-c835-417f-8103-425af7abd38f", "AQAAAAEAACcQAAAAENXUNKqoJE084GE6OV3xI4JpmlFqhCkK34bO7IpRTzd0it0GAFJ2QLTvjLQ0U5i+SQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f6222485-0339-436f-b36a-02bf453b2b36", "AQAAAAEAACcQAAAAEHby/7X/RIK8zyVE+K+BWhm76J0eMHnWfn+Dbhaj95hqhGXsj3JwfLDG6A+r0pHuwg==" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer_Quest.Migrations
{
    public partial class added_phone_and_email : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed" },
                values: new object[] { "f6222485-0339-436f-b36a-02bf453b2b36", "admin@admin.com", "AQAAAAEAACcQAAAAEHby/7X/RIK8zyVE+K+BWhm76J0eMHnWfn+Dbhaj95hqhGXsj3JwfLDG6A+r0pHuwg==", "(989)464-5890", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed" },
                values: new object[] { "cc1f810b-0db3-4b3f-b1cf-0b74c3a65bca", null, "AQAAAAEAACcQAAAAEMfnsu0wFDwT9KpIV4IR7cgMk4CnjD+kNT9dyNqj78GuGrurXVHbIINbvZt7E86jLA==", null, false });
        }
    }
}

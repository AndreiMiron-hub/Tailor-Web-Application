using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TailorWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34d9898f-d312-4d46-b109-11bb40eb12ba",
                column: "ConcurrencyStamp",
                value: "10d52b26-d1f9-4170-b529-3bf6c14db568");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a436a18-b376-4cda-83c7-b221dcfc58dd",
                column: "ConcurrencyStamp",
                value: "ebeff00a-aa72-4497-92d0-5a1a59d54ef3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Staff",
                column: "ConcurrencyStamp",
                value: "3c7c75e0-fe47-4932-9126-9d478e9a0522");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90dafc5d-922a-4de8-94cf-4538db5586ab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78a61fcb-7c5f-49ba-93c2-94b202a56d40", "AQAAAAEAACcQAAAAEKf+PCT6b6VRTaHfWnRTPtMWkxJ8DSridol82F5wZF3xr87BC9HPLuYC1mvaG4EM0g==", "f65670a3-c240-4421-a616-f005dd6bb89f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34d9898f-d312-4d46-b109-11bb40eb12ba",
                column: "ConcurrencyStamp",
                value: "6c3e5379-91bf-4d9e-9e2f-43bad3ac1325");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a436a18-b376-4cda-83c7-b221dcfc58dd",
                column: "ConcurrencyStamp",
                value: "5903d748-33f7-4e69-89e4-b8cc47bda26b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Staff",
                column: "ConcurrencyStamp",
                value: "ffa56694-2228-4812-b83a-7367d8926ca2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90dafc5d-922a-4de8-94cf-4538db5586ab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6e63e66-7383-405e-9dac-8e2ef4cd8b0b", "AQAAAAEAACcQAAAAECOgro4a4P6hhR1/OgxgSpOtsQQGFEtwPIEXowYM5dW4isEojEIq3qBxXFbc/+tJdw==", "847fb585-db7f-460e-9daa-90df508d94c5" });
        }
    }
}

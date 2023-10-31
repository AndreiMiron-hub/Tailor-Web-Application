using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TailorWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_OfferedServices_ServiceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Orders_OrderId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_OrderId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentEndTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "AppointmentStartTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34d9898f-d312-4d46-b109-11bb40eb12ba",
                column: "ConcurrencyStamp",
                value: "2dfa6279-ce54-4248-8ff0-861b761e3fdc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a436a18-b376-4cda-83c7-b221dcfc58dd",
                column: "ConcurrencyStamp",
                value: "eab16cae-febf-46bd-9755-63c4ec9d1a0c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "Staff",
                column: "ConcurrencyStamp",
                value: "6198fb57-0263-4ae6-9c7a-3409f1f5f880");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90dafc5d-922a-4de8-94cf-4538db5586ab",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d827dce9-31f2-4d82-a871-d9ba016cc945", "AQAAAAEAACcQAAAAELPVepWinglGU6GpvinYKTwrpwTAJR+REE8nXeTs3aPxjEtarQ9CmajWsVwaygPn3w==", "f7062944-03bd-45f7-ba0b-d2d5f1237d48" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentEndTime",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentStartTime",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Appointments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "Appointments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_OrderId",
                table: "Appointments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_OfferedServices_ServiceId",
                table: "Appointments",
                column: "ServiceId",
                principalTable: "OfferedServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Orders_OrderId",
                table: "Appointments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}

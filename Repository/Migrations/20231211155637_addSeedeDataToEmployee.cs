using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addSeedeDataToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Age", "CreatedDate", "FullName", "SoftDeleted" },
                values: new object[] { 1, "Xalqlar", 25, new DateTime(2023, 12, 11, 19, 56, 37, 526, DateTimeKind.Local).AddTicks(8040), "Kubra Memmedova", false });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Age", "CreatedDate", "FullName", "SoftDeleted" },
                values: new object[] { 2, "Vasmoy", 24, new DateTime(2023, 12, 11, 19, 56, 37, 526, DateTimeKind.Local).AddTicks(8090), "Surac Ismayilov", false });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Age", "CreatedDate", "FullName", "SoftDeleted" },
                values: new object[] { 3, "Yasamal", 30, new DateTime(2023, 12, 11, 19, 56, 37, 526, DateTimeKind.Local).AddTicks(8090), "Pervin Mirzeyev", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}

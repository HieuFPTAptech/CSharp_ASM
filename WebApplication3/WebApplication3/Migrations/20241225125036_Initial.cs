using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 19, 50, 36, 287, DateTimeKind.Local).AddTicks(8666));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 19, 39, 35, 730, DateTimeKind.Local).AddTicks(5900));
        }
    }
}

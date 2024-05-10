using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2fff7969-3273-4120-9188-ff0a795a1121"), "Finance" },
                    { new Guid("ad9a351a-6aa7-4ebb-b75e-317c8f5c88fb"), "Accountant" },
                    { new Guid("b1cdb409-aabf-43b7-a3fa-76135bb64702"), "HR" },
                    { new Guid("efe6d7a0-f716-4b74-9ff6-0bf5c5c00e10"), "Software Development" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("2fff7969-3273-4120-9188-ff0a795a1121"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ad9a351a-6aa7-4ebb-b75e-317c8f5c88fb"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("b1cdb409-aabf-43b7-a3fa-76135bb64702"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("efe6d7a0-f716-4b74-9ff6-0bf5c5c00e10"));
        }
    }
}

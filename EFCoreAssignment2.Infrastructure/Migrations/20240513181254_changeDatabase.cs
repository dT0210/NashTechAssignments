using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreAssignment2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("4bf5fdda-85e6-484f-8089-1c421d7ae331"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("6702abf3-732c-44e2-b87c-6b8eaaae491f"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7bf001bf-bbf6-4234-91d8-aafbcd710f41"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8cf70e70-21ca-44f1-a675-f4c154887801"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8fe432b0-61fc-4a06-a1ff-0cf28df94b8c"), "HR" },
                    { new Guid("95606f3d-0e21-4e46-8298-f82fb5054df3"), "Accountant" },
                    { new Guid("e2ef721f-3ae6-46de-a346-afb48e36c7b5"), "Software Development" },
                    { new Guid("faf7d747-7e73-4661-b944-0dfc5096d83e"), "Finance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8fe432b0-61fc-4a06-a1ff-0cf28df94b8c"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("95606f3d-0e21-4e46-8298-f82fb5054df3"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e2ef721f-3ae6-46de-a346-afb48e36c7b5"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("faf7d747-7e73-4661-b944-0dfc5096d83e"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4bf5fdda-85e6-484f-8089-1c421d7ae331"), "HR" },
                    { new Guid("6702abf3-732c-44e2-b87c-6b8eaaae491f"), "Software Development" },
                    { new Guid("7bf001bf-bbf6-4234-91d8-aafbcd710f41"), "Finance" },
                    { new Guid("8cf70e70-21ca-44f1-a675-f4c154887801"), "Accountant" }
                });
        }
    }
}

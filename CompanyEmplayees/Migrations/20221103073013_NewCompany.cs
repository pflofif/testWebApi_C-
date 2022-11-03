using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmplayees.Migrations
{
    public partial class NewCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[] { new Guid("3d432a70-94ce-4d15-9494-5248280c2ce3"), "412 Forest Avenue, BF 923", "USA", "Project_Solution Ltd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("3d432a70-94ce-4d15-9494-5248280c2ce3"));
        }
    }
}

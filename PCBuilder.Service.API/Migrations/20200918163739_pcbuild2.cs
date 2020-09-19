using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCBuilder.Service.API.Migrations
{
    public partial class pcbuild2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Processors",
                columns: new[] { "Id", "Cache", "Link", "Name", "NumberOfCores", "NumberOfThreads", "Price", "ProcessorBaseFrequency", "ProductCollection", "TDP" },
                values: new object[] { new Guid("4b174e6f-53b5-4ada-8297-2dbcf983bc76"), 8, null, null, 4, 4, 0m, 1m, "i7 10th gen", 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Processors",
                keyColumn: "Id",
                keyValue: new Guid("4b174e6f-53b5-4ada-8297-2dbcf983bc76"));
        }
    }
}

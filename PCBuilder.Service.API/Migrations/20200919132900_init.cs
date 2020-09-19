using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCBuilder.Service.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CPU = table.Column<string>(nullable: true),
                    Chipset = table.Column<string>(nullable: true),
                    Socket = table.Column<string>(nullable: true),
                    Memory = table.Column<string>(nullable: true),
                    FormFactor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductCollection = table.Column<string>(nullable: true),
                    NumberOfCores = table.Column<int>(nullable: false),
                    NumberOfThreads = table.Column<int>(nullable: false),
                    Cache = table.Column<int>(nullable: false),
                    TDP = table.Column<int>(nullable: false),
                    ProcessorBaseFrequency = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCBuilds",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcessorId = table.Column<Guid>(nullable: true),
                    MotherboardId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCBuilds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCBuilds_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCBuilds_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Processors",
                columns: new[] { "Id", "Cache", "CreatedDate", "Link", "ModifiedDate", "Name", "NumberOfCores", "NumberOfThreads", "Price", "ProcessorBaseFrequency", "ProductCollection", "TDP" },
                values: new object[] { new Guid("90b85e79-9dae-4ff2-8a66-51ef22df23ae"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "no url", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "i7", 4, 4, 0m, 1m, "i7 10th gen", 100 });

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_MotherboardId",
                table: "PCBuilds",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_ProcessorId",
                table: "PCBuilds",
                column: "ProcessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCBuilds");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Processors");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCBuilder.Service.API.Migrations
{
    public partial class pcbuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    Description = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    ProcessorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCBuilds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCBuilds_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Processors");
        }
    }
}

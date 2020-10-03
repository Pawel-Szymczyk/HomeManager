using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCBuilder.Service.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CPUWatercooler",
                columns: table => new
                {
                    CPUWatercoolerId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dimensions = table.Column<string>(nullable: true),
                    SocketsCompatibility = table.Column<string>(nullable: true),
                    NumberOfFans = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUWatercooler", x => x.CPUWatercoolerId);
                });

            migrationBuilder.CreateTable(
                name: "Fan",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dimensions = table.Column<string>(nullable: true),
                    NumberOfFuns = table.Column<int>(nullable: false),
                    PWMControl = table.Column<bool>(nullable: false),
                    RGB = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraphicsCards",
                columns: table => new
                {
                    GraphicsCardId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dimensions = table.Column<string>(nullable: true),
                    GPU = table.Column<string>(nullable: true),
                    GPUFrequency = table.Column<string>(nullable: true),
                    BoostClock = table.Column<string>(nullable: true),
                    MemoryType = table.Column<string>(nullable: true),
                    CUDA = table.Column<int>(nullable: false),
                    PSU = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsCards", x => x.GraphicsCardId);
                });

            migrationBuilder.CreateTable(
                name: "HardDrives",
                columns: table => new
                {
                    HardDriveId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capacity = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardDrives", x => x.HardDriveId);
                });

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
                name: "Others",
                columns: table => new
                {
                    OtherId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.OtherId);
                });

            migrationBuilder.CreateTable(
                name: "PCCase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    FormFactor = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    MotherboardSupport = table.Column<string>(nullable: true),
                    SideWindow = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCCase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupply",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Power = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Certificate = table.Column<string>(nullable: true),
                    ModularCables = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupply", x => x.Id);
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
                name: "RAMs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MemoryType = table.Column<string>(nullable: true),
                    MemorySpeed = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    ChipsetCompatibility = table.Column<string>(nullable: true),
                    NumberOfModules = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCBuilds",
                columns: table => new
                {
                    PCBuildId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CPUWatercoolerId = table.Column<Guid>(nullable: true),
                    FanId = table.Column<Guid>(nullable: true),
                    MotherboardId = table.Column<Guid>(nullable: true),
                    PCCaseId = table.Column<Guid>(nullable: true),
                    PowerSupplyId = table.Column<Guid>(nullable: true),
                    ProcessorId = table.Column<Guid>(nullable: true),
                    RAMId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCBuilds", x => x.PCBuildId);
                    table.ForeignKey(
                        name: "FK_PCBuilds_CPUWatercooler_CPUWatercoolerId",
                        column: x => x.CPUWatercoolerId,
                        principalTable: "CPUWatercooler",
                        principalColumn: "CPUWatercoolerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCBuilds_Fan_FanId",
                        column: x => x.FanId,
                        principalTable: "Fan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCBuilds_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCBuilds_PCCase_PCCaseId",
                        column: x => x.PCCaseId,
                        principalTable: "PCCase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCBuilds_PowerSupply_PowerSupplyId",
                        column: x => x.PowerSupplyId,
                        principalTable: "PowerSupply",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCBuilds_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCBuilds_RAMs_RAMId",
                        column: x => x.RAMId,
                        principalTable: "RAMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PCBuildGraphicsCard",
                columns: table => new
                {
                    PCBuildId = table.Column<Guid>(nullable: false),
                    GraphicsCardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCBuildGraphicsCard", x => new { x.PCBuildId, x.GraphicsCardId });
                    table.ForeignKey(
                        name: "FK_PCBuildGraphicsCard_GraphicsCards_GraphicsCardId",
                        column: x => x.GraphicsCardId,
                        principalTable: "GraphicsCards",
                        principalColumn: "GraphicsCardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCBuildGraphicsCard_PCBuilds_PCBuildId",
                        column: x => x.PCBuildId,
                        principalTable: "PCBuilds",
                        principalColumn: "PCBuildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCBuildHardDrive",
                columns: table => new
                {
                    PCBuildId = table.Column<Guid>(nullable: false),
                    HardDriveId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCBuildHardDrive", x => new { x.PCBuildId, x.HardDriveId });
                    table.ForeignKey(
                        name: "FK_PCBuildHardDrive_HardDrives_HardDriveId",
                        column: x => x.HardDriveId,
                        principalTable: "HardDrives",
                        principalColumn: "HardDriveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCBuildHardDrive_PCBuilds_PCBuildId",
                        column: x => x.PCBuildId,
                        principalTable: "PCBuilds",
                        principalColumn: "PCBuildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCBuildOther",
                columns: table => new
                {
                    PCBuildId = table.Column<Guid>(nullable: false),
                    OtherId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCBuildOther", x => new { x.PCBuildId, x.OtherId });
                    table.ForeignKey(
                        name: "FK_PCBuildOther_Others_OtherId",
                        column: x => x.OtherId,
                        principalTable: "Others",
                        principalColumn: "OtherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCBuildOther_PCBuilds_PCBuildId",
                        column: x => x.PCBuildId,
                        principalTable: "PCBuilds",
                        principalColumn: "PCBuildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Processors",
                columns: new[] { "Id", "Cache", "CreatedDate", "Link", "ModifiedDate", "Name", "NumberOfCores", "NumberOfThreads", "Price", "ProcessorBaseFrequency", "ProductCollection", "TDP" },
                values: new object[] { new Guid("ce93df78-3d8b-4189-95a2-07656f45e22a"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "no url", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "i7", 4, 4, 0m, 1m, "i7 10th gen", 100 });

            migrationBuilder.CreateIndex(
                name: "IX_PCBuildGraphicsCard_GraphicsCardId",
                table: "PCBuildGraphicsCard",
                column: "GraphicsCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuildHardDrive_HardDriveId",
                table: "PCBuildHardDrive",
                column: "HardDriveId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuildOther_OtherId",
                table: "PCBuildOther",
                column: "OtherId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_CPUWatercoolerId",
                table: "PCBuilds",
                column: "CPUWatercoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_FanId",
                table: "PCBuilds",
                column: "FanId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_MotherboardId",
                table: "PCBuilds",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_PCCaseId",
                table: "PCBuilds",
                column: "PCCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_PowerSupplyId",
                table: "PCBuilds",
                column: "PowerSupplyId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_ProcessorId",
                table: "PCBuilds",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_PCBuilds_RAMId",
                table: "PCBuilds",
                column: "RAMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCBuildGraphicsCard");

            migrationBuilder.DropTable(
                name: "PCBuildHardDrive");

            migrationBuilder.DropTable(
                name: "PCBuildOther");

            migrationBuilder.DropTable(
                name: "GraphicsCards");

            migrationBuilder.DropTable(
                name: "HardDrives");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "PCBuilds");

            migrationBuilder.DropTable(
                name: "CPUWatercooler");

            migrationBuilder.DropTable(
                name: "Fan");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "PCCase");

            migrationBuilder.DropTable(
                name: "PowerSupply");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "RAMs");
        }
    }
}

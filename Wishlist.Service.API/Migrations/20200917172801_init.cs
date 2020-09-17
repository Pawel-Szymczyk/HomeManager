using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wishlist.Service.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occasions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occasions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OccasionId = table.Column<Guid>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entities_Occasions_OccasionId",
                        column: x => x.OccasionId,
                        principalTable: "Occasions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Occasions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("db6f100a-e46c-4dad-81a0-340765cc65e3"), "There is no occasion, but don't forget about yourself.", "NoOccasion" },
                    { new Guid("e3ab66ee-6c04-471d-a0db-6e0c9917d3ef"), "Someone celebrates birthday, don't forget about a nice present.", "BirthdayPresent" },
                    { new Guid("ef1f9b84-7e2a-4f16-be3e-62601a7f539f"), "Christmas time, there is no better time for presents.", "ChristmasPresent" },
                    { new Guid("974247f9-d42a-4bb8-8602-3af75572eb83"), "Need more stuf, movement is great opportunity to rid of old things.", "Movement" },
                    { new Guid("4e9b1fe5-627a-4a9f-bf2c-830cd074381d"), "Any other situation you didn't think of.", "Others" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_OccasionId",
                table: "Entities",
                column: "OccasionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Occasions");
        }
    }
}

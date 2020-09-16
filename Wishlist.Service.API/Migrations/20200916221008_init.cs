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
                    OccasionId = table.Column<Guid>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Occasions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("44cf9b67-23a0-48ec-b4e3-3bbe0adca579"), "There is no occasion, but don't forget about yourself.", "NoOccasion" },
                    { new Guid("7291e7e0-f39e-4b21-89f5-a0c7d3de7a23"), "Someone celebrates birthday, don't forget about a nice present.", "BirthdayPresent" },
                    { new Guid("971f4e2e-29e8-44ab-bd0d-35a74c0fdcbc"), "Christmas time, there is no better time for presents.", "ChristmasPresent" },
                    { new Guid("7cae9d95-a59f-4af3-b3fb-ce505becf610"), "Need more stuf, movement is great opportunity to rid of old things.", "Movement" },
                    { new Guid("00475bd8-13bd-4c2f-9a2e-5def18537e3a"), "Any other situation you didn't think of.", "Others" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_OccasionId",
                table: "Entities",
                column: "OccasionId",
                unique: true);
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

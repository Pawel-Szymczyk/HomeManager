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
                    { new Guid("88dfb763-1e5f-43fb-b8bb-7abc20eba4b0"), "There is no occasion, but don't forget about yourself.", "NoOccasion" },
                    { new Guid("dd86dc9b-5cd2-4548-83bb-4cd233dc6f26"), "Someone celebrates birthday, don't forget about a nice present.", "BirthdayPresent" },
                    { new Guid("2b9fb10a-a0c2-4e62-957b-3262a2428c5d"), "Christmas time, there is no better time for presents.", "ChristmasPresent" },
                    { new Guid("947c82e9-e6a0-478d-98b0-ca05609f4c8e"), "Need more stuf, movement is great opportunity to rid of old things.", "Movement" },
                    { new Guid("bea093d4-7deb-4766-bcb7-00cf48f468ad"), "Any other situation you didn't think of.", "Others" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_OccasionId",
                table: "Entities",
                column: "OccasionId",
                unique: true,
                filter: "[OccasionId] IS NOT NULL");
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

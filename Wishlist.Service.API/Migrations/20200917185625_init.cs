using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wishlist.Service.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
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
                    StateId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entities_Occasions_OccasionId",
                        column: x => x.OccasionId,
                        principalTable: "Occasions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a1863048-bdad-4d01-a1ec-83b24dcb8274"), "There is no valid category for you, sorry.", "NoCategory" },
                    { new Guid("c952a537-2e50-4bac-af20-c9fdf3e513fe"), "Money, money and agian money, you need them.", "Savings" },
                    { new Guid("f8c726ab-e634-4409-9f8d-f3c7d6e6966d"), "Put here everything everything what you think makes you relaxed.", "Relax" },
                    { new Guid("186e9926-e3e0-4164-a61c-d790efa0653c"), "Any other category you didn't think of.", "Other" },
                    { new Guid("95fe5581-23df-4cfd-9c6a-3d87f90f7951"), "Listen, listen... can you hear? This silence.", "Music" },
                    { new Guid("de24d5ae-6438-409d-a1b1-a65863b3d3a6"), "Home, sweet home.", "Home" },
                    { new Guid("760408b9-1c99-4ea5-9244-a701b23dc152"), "Hobby category, put here everything you want.", "Hobby" },
                    { new Guid("8a33313c-30a3-4e8b-8809-c2d5f10e3e3a"), "One of the best jobs and hobbies ever.", "Programming" },
                    { new Guid("af8a7c1e-11ee-4c46-893f-2e69c28d1e73"), "Hobby is important don't forget about the most important.", "Motorcycle" },
                    { new Guid("07fc2b80-aa6b-489e-a376-e69e62684bba"), "AGD, RTV ?.", "Electronics" },
                    { new Guid("3ce7c598-1d81-46b5-88a7-33dd49bb07c7"), "Tool, toy, sense of live.", "Computer" },
                    { new Guid("e9076572-d974-402d-bf92-0bce65cc0d81"), "Car one of the best man friend.", "Car" },
                    { new Guid("4c1ae8cb-ce73-4ffd-b19c-3f95060f8bc4"), "Literature is important, just don't asleep.", "Book" },
                    { new Guid("43ff64aa-993a-41e5-89a4-a5848b67ca28"), "Vodka, Whisky, Wine, Beer... just stop.", "Alcohol" },
                    { new Guid("bfb24c33-82c4-4454-837b-72c0ef1da991"), "Health is important, take care about it.", "Health" }
                });

            migrationBuilder.InsertData(
                table: "Occasions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("5229afaa-2247-4fa7-a63e-a453d64aa9a8"), "Any other situation you didn't think of.", "Others" },
                    { new Guid("c4aea200-b799-4772-9ba1-e6187453ddb4"), "Need more stuf, movement is great opportunity to rid of old things.", "Movement" },
                    { new Guid("d4cb508d-b447-492b-b778-1ec38e64d86d"), "Someone celebrates birthday, don't forget about a nice present.", "BirthdayPresent" },
                    { new Guid("85ccb780-81b7-4325-abf0-1f283aaa4058"), "There is no occasion, but don't forget about yourself.", "NoOccasion" },
                    { new Guid("b905f29b-1b92-4ba0-821f-c85a6cd13d67"), "Christmas time, there is no better time for presents.", "ChristmasPresent" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a027a949-c993-4dce-bd78-87f3715bebb1"), "I do not need it, yet.", "RejectedIdea" },
                    { new Guid("6418a83f-c7b3-4189-8abc-58a0b1afb1d6"), "I plan to buy it.", "PlanningToBuy" },
                    { new Guid("1ff62eb2-9814-4b70-9f2e-b5a6e9beab65"), "I bought it, I have it, I enjoy it.", "Bought" },
                    { new Guid("e203ea86-6ae0-4ef5-92ab-38683561a634"), "I think I need it.", "ThinkingOfBuying" },
                    { new Guid("603dccb4-2f5d-42cd-aa9a-b859184d6d7b"), "I think I need it, but not now.", "PostponedLater" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_CategoryId",
                table: "Entities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_OccasionId",
                table: "Entities",
                column: "OccasionId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_StateId",
                table: "Entities",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Occasions");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}

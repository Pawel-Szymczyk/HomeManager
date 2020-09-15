using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wishlist.Service.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishlistEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Occasion = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishlistEntities");
        }
    }
}

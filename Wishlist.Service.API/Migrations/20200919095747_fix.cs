using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wishlist.Service.API.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("07fc2b80-aa6b-489e-a376-e69e62684bba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("186e9926-e3e0-4164-a61c-d790efa0653c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3ce7c598-1d81-46b5-88a7-33dd49bb07c7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43ff64aa-993a-41e5-89a4-a5848b67ca28"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4c1ae8cb-ce73-4ffd-b19c-3f95060f8bc4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("760408b9-1c99-4ea5-9244-a701b23dc152"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8a33313c-30a3-4e8b-8809-c2d5f10e3e3a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("95fe5581-23df-4cfd-9c6a-3d87f90f7951"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a1863048-bdad-4d01-a1ec-83b24dcb8274"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af8a7c1e-11ee-4c46-893f-2e69c28d1e73"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bfb24c33-82c4-4454-837b-72c0ef1da991"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c952a537-2e50-4bac-af20-c9fdf3e513fe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("de24d5ae-6438-409d-a1b1-a65863b3d3a6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e9076572-d974-402d-bf92-0bce65cc0d81"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f8c726ab-e634-4409-9f8d-f3c7d6e6966d"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("5229afaa-2247-4fa7-a63e-a453d64aa9a8"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("85ccb780-81b7-4325-abf0-1f283aaa4058"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("b905f29b-1b92-4ba0-821f-c85a6cd13d67"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("c4aea200-b799-4772-9ba1-e6187453ddb4"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("d4cb508d-b447-492b-b778-1ec38e64d86d"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("1ff62eb2-9814-4b70-9f2e-b5a6e9beab65"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("603dccb4-2f5d-42cd-aa9a-b859184d6d7b"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("6418a83f-c7b3-4189-8abc-58a0b1afb1d6"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a027a949-c993-4dce-bd78-87f3715bebb1"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("e203ea86-6ae0-4ef5-92ab-38683561a634"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "Entities");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Entities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Entities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("132148e9-443b-4bf2-ae5c-e4545c96b86f"), "There is no valid category for you, sorry.", "NoCategory" },
                    { new Guid("1662c69a-13cb-4457-87ae-c257ea8daaa3"), "Money, money and agian money, you need them.", "Savings" },
                    { new Guid("e90f1b68-80de-4327-81dc-e26c9e9b8418"), "Put here everything everything what you think makes you relaxed.", "Relax" },
                    { new Guid("6c0f594c-9ef5-44f0-979a-d17b1b9e29f2"), "Any other category you didn't think of.", "Other" },
                    { new Guid("f3cb1afc-1bca-414c-8dfd-d8144b61a0e2"), "Listen, listen... can you hear? This silence.", "Music" },
                    { new Guid("49267df0-d34c-4307-ba77-536cbff6bfc0"), "Home, sweet home.", "Home" },
                    { new Guid("ab871354-d271-41ec-a904-8ce3e26033f9"), "Hobby category, put here everything you want.", "Hobby" },
                    { new Guid("947f4a41-34a3-4327-9071-8ddaa9f90b79"), "One of the best jobs and hobbies ever.", "Programming" },
                    { new Guid("d51aa392-66f7-4887-b8d2-b6f1c6c545f8"), "Hobby is important don't forget about the most important.", "Motorcycle" },
                    { new Guid("392bb781-a560-425d-8800-a0e5ac9ec9e7"), "AGD, RTV ?.", "Electronics" },
                    { new Guid("e276b0a4-11e5-4083-9d2e-730d4c6e4312"), "Tool, toy, sense of live.", "Computer" },
                    { new Guid("8d799ac1-0d30-45d1-bea9-1b0924786a83"), "Car one of the best man friend.", "Car" },
                    { new Guid("d7fe3903-29e8-491f-bcc8-0ba3e6b0f149"), "Literature is important, just don't asleep.", "Book" },
                    { new Guid("63ad0b24-5791-485e-8e00-6caf4b5ea832"), "Vodka, Whisky, Wine, Beer... just stop.", "Alcohol" },
                    { new Guid("d48d26c2-9449-45b3-8131-d9e54dd1344a"), "Health is important, take care about it.", "Health" }
                });

            migrationBuilder.InsertData(
                table: "Occasions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("b8c0e447-32e2-4a48-ac1c-4d59c84e07d0"), "Any other situation you didn't think of.", "Others" },
                    { new Guid("b3fb5458-27d8-482c-afc4-fef29e0eb3d2"), "Need more stuf, movement is great opportunity to rid of old things.", "Movement" },
                    { new Guid("4d87d81f-3b77-47fa-9333-017ede3bd1ab"), "Someone celebrates birthday, don't forget about a nice present.", "BirthdayPresent" },
                    { new Guid("ef754082-8b24-49cb-86a0-8c361668435c"), "There is no occasion, but don't forget about yourself.", "NoOccasion" },
                    { new Guid("3908be77-4767-4dd5-8afd-a46f315cfc5d"), "Christmas time, there is no better time for presents.", "ChristmasPresent" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0f84aed0-82db-4f11-b2dc-cdbc7ba93a22"), "I do not need it, yet.", "RejectedIdea" },
                    { new Guid("125c7250-ab8d-4a65-9cb7-8b1206f8d9f4"), "I plan to buy it.", "PlanningToBuy" },
                    { new Guid("a54e033e-e4a7-49e2-b0a0-30f1515fb156"), "I bought it, I have it, I enjoy it.", "Bought" },
                    { new Guid("fe3e6929-a4bd-4b15-afc5-4b7e2ca17dbf"), "I think I need it.", "ThinkingOfBuying" },
                    { new Guid("50cd981d-2195-4e26-891d-56c158f1a84f"), "I think I need it, but not now.", "PostponedLater" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("132148e9-443b-4bf2-ae5c-e4545c96b86f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1662c69a-13cb-4457-87ae-c257ea8daaa3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392bb781-a560-425d-8800-a0e5ac9ec9e7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("49267df0-d34c-4307-ba77-536cbff6bfc0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63ad0b24-5791-485e-8e00-6caf4b5ea832"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c0f594c-9ef5-44f0-979a-d17b1b9e29f2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d799ac1-0d30-45d1-bea9-1b0924786a83"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("947f4a41-34a3-4327-9071-8ddaa9f90b79"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ab871354-d271-41ec-a904-8ce3e26033f9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d48d26c2-9449-45b3-8131-d9e54dd1344a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d51aa392-66f7-4887-b8d2-b6f1c6c545f8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d7fe3903-29e8-491f-bcc8-0ba3e6b0f149"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e276b0a4-11e5-4083-9d2e-730d4c6e4312"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e90f1b68-80de-4327-81dc-e26c9e9b8418"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f3cb1afc-1bca-414c-8dfd-d8144b61a0e2"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("3908be77-4767-4dd5-8afd-a46f315cfc5d"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("4d87d81f-3b77-47fa-9333-017ede3bd1ab"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("b3fb5458-27d8-482c-afc4-fef29e0eb3d2"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("b8c0e447-32e2-4a48-ac1c-4d59c84e07d0"));

            migrationBuilder.DeleteData(
                table: "Occasions",
                keyColumn: "Id",
                keyValue: new Guid("ef754082-8b24-49cb-86a0-8c361668435c"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("0f84aed0-82db-4f11-b2dc-cdbc7ba93a22"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("125c7250-ab8d-4a65-9cb7-8b1206f8d9f4"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("50cd981d-2195-4e26-891d-56c158f1a84f"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("a54e033e-e4a7-49e2-b0a0-30f1515fb156"));

            migrationBuilder.DeleteData(
                table: "States",
                keyColumn: "Id",
                keyValue: new Guid("fe3e6929-a4bd-4b15-afc5-4b7e2ca17dbf"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Entities");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Entities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "Entities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wishlist.Service.API.DBContext;

namespace Wishlist.Service.API.Migrations
{
    [DbContext(typeof(WishlistContext))]
    partial class WishlistContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wishlist.Service.API.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("132148e9-443b-4bf2-ae5c-e4545c96b86f"),
                            Description = "There is no valid category for you, sorry.",
                            Name = "NoCategory"
                        },
                        new
                        {
                            Id = new Guid("63ad0b24-5791-485e-8e00-6caf4b5ea832"),
                            Description = "Vodka, Whisky, Wine, Beer... just stop.",
                            Name = "Alcohol"
                        },
                        new
                        {
                            Id = new Guid("d7fe3903-29e8-491f-bcc8-0ba3e6b0f149"),
                            Description = "Literature is important, just don't asleep.",
                            Name = "Book"
                        },
                        new
                        {
                            Id = new Guid("8d799ac1-0d30-45d1-bea9-1b0924786a83"),
                            Description = "Car one of the best man friend.",
                            Name = "Car"
                        },
                        new
                        {
                            Id = new Guid("e276b0a4-11e5-4083-9d2e-730d4c6e4312"),
                            Description = "Tool, toy, sense of live.",
                            Name = "Computer"
                        },
                        new
                        {
                            Id = new Guid("392bb781-a560-425d-8800-a0e5ac9ec9e7"),
                            Description = "AGD, RTV ?.",
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = new Guid("d51aa392-66f7-4887-b8d2-b6f1c6c545f8"),
                            Description = "Hobby is important don't forget about the most important.",
                            Name = "Motorcycle"
                        },
                        new
                        {
                            Id = new Guid("d48d26c2-9449-45b3-8131-d9e54dd1344a"),
                            Description = "Health is important, take care about it.",
                            Name = "Health"
                        },
                        new
                        {
                            Id = new Guid("ab871354-d271-41ec-a904-8ce3e26033f9"),
                            Description = "Hobby category, put here everything you want.",
                            Name = "Hobby"
                        },
                        new
                        {
                            Id = new Guid("49267df0-d34c-4307-ba77-536cbff6bfc0"),
                            Description = "Home, sweet home.",
                            Name = "Home"
                        },
                        new
                        {
                            Id = new Guid("f3cb1afc-1bca-414c-8dfd-d8144b61a0e2"),
                            Description = "Listen, listen... can you hear? This silence.",
                            Name = "Music"
                        },
                        new
                        {
                            Id = new Guid("6c0f594c-9ef5-44f0-979a-d17b1b9e29f2"),
                            Description = "Any other category you didn't think of.",
                            Name = "Other"
                        },
                        new
                        {
                            Id = new Guid("947f4a41-34a3-4327-9071-8ddaa9f90b79"),
                            Description = "One of the best jobs and hobbies ever.",
                            Name = "Programming"
                        },
                        new
                        {
                            Id = new Guid("e90f1b68-80de-4327-81dc-e26c9e9b8418"),
                            Description = "Put here everything everything what you think makes you relaxed.",
                            Name = "Relax"
                        },
                        new
                        {
                            Id = new Guid("1662c69a-13cb-4457-87ae-c257ea8daaa3"),
                            Description = "Money, money and agian money, you need them.",
                            Name = "Savings"
                        });
                });

            modelBuilder.Entity("Wishlist.Service.API.Models.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OccasionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OccasionId");

                    b.HasIndex("StateId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Wishlist.Service.API.Models.Occasion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Occasions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ef754082-8b24-49cb-86a0-8c361668435c"),
                            Description = "There is no occasion, but don't forget about yourself.",
                            Name = "NoOccasion"
                        },
                        new
                        {
                            Id = new Guid("4d87d81f-3b77-47fa-9333-017ede3bd1ab"),
                            Description = "Someone celebrates birthday, don't forget about a nice present.",
                            Name = "BirthdayPresent"
                        },
                        new
                        {
                            Id = new Guid("3908be77-4767-4dd5-8afd-a46f315cfc5d"),
                            Description = "Christmas time, there is no better time for presents.",
                            Name = "ChristmasPresent"
                        },
                        new
                        {
                            Id = new Guid("b3fb5458-27d8-482c-afc4-fef29e0eb3d2"),
                            Description = "Need more stuf, movement is great opportunity to rid of old things.",
                            Name = "Movement"
                        },
                        new
                        {
                            Id = new Guid("b8c0e447-32e2-4a48-ac1c-4d59c84e07d0"),
                            Description = "Any other situation you didn't think of.",
                            Name = "Others"
                        });
                });

            modelBuilder.Entity("Wishlist.Service.API.Models.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = new Guid("125c7250-ab8d-4a65-9cb7-8b1206f8d9f4"),
                            Description = "I plan to buy it.",
                            Name = "PlanningToBuy"
                        },
                        new
                        {
                            Id = new Guid("a54e033e-e4a7-49e2-b0a0-30f1515fb156"),
                            Description = "I bought it, I have it, I enjoy it.",
                            Name = "Bought"
                        },
                        new
                        {
                            Id = new Guid("fe3e6929-a4bd-4b15-afc5-4b7e2ca17dbf"),
                            Description = "I think I need it.",
                            Name = "ThinkingOfBuying"
                        },
                        new
                        {
                            Id = new Guid("0f84aed0-82db-4f11-b2dc-cdbc7ba93a22"),
                            Description = "I do not need it, yet.",
                            Name = "RejectedIdea"
                        },
                        new
                        {
                            Id = new Guid("50cd981d-2195-4e26-891d-56c158f1a84f"),
                            Description = "I think I need it, but not now.",
                            Name = "PostponedLater"
                        });
                });

            modelBuilder.Entity("Wishlist.Service.API.Models.Entity", b =>
                {
                    b.HasOne("Wishlist.Service.API.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Wishlist.Service.API.Models.Occasion", "Occasion")
                        .WithMany()
                        .HasForeignKey("OccasionId");

                    b.HasOne("Wishlist.Service.API.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });
#pragma warning restore 612, 618
        }
    }
}

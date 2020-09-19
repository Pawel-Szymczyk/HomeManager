﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCBuilder.Service.API.DBContext;

namespace PCBuilder.Service.API.Migrations
{
    [DbContext(typeof(PCBuilderContext))]
    [Migration("20200919132900_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PCBuilder.Service.API.Models.Motherboard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chipset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormFactor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Socket")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("PCBuilder.Service.API.Models.PCBuild", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MotherboardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProcessorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("ProcessorId");

                    b.ToTable("PCBuilds");
                });

            modelBuilder.Entity("PCBuilder.Service.API.Models.Processor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Cache")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCores")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfThreads")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ProcessorBaseFrequency")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductCollection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TDP")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Processors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("90b85e79-9dae-4ff2-8a66-51ef22df23ae"),
                            Cache = 8,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Link = "no url",
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "i7",
                            NumberOfCores = 4,
                            NumberOfThreads = 4,
                            Price = 0m,
                            ProcessorBaseFrequency = 1m,
                            ProductCollection = "i7 10th gen",
                            TDP = 100
                        });
                });

            modelBuilder.Entity("PCBuilder.Service.API.Models.PCBuild", b =>
                {
                    b.HasOne("PCBuilder.Service.API.Models.Motherboard", "Motherboard")
                        .WithMany()
                        .HasForeignKey("MotherboardId");

                    b.HasOne("PCBuilder.Service.API.Models.Processor", "Processor")
                        .WithMany()
                        .HasForeignKey("ProcessorId");
                });
#pragma warning restore 612, 618
        }
    }
}
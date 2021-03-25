﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceEngine;

namespace SpaceEngine.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210323151411_New_Table_Receipt")]
    partial class New_Table_Receipt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpaceEngine.Model.Receipt", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParkingspotID")
                        .HasColumnType("int");

                    b.Property<string>("StarshipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ParkingspotID");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("SpaceEngine.Parkingspot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<string>("CharacterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxSize")
                        .HasColumnType("int");

                    b.Property<int>("MinSize")
                        .HasColumnType("int");

                    b.Property<string>("SpaceshipName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Parkingspots");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Arrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxSize = 500,
                            MinSize = 0
                        },
                        new
                        {
                            ID = 2,
                            Arrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxSize = 500,
                            MinSize = 0
                        },
                        new
                        {
                            ID = 3,
                            Arrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxSize = 500,
                            MinSize = 0
                        },
                        new
                        {
                            ID = 4,
                            Arrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxSize = 500,
                            MinSize = 0
                        },
                        new
                        {
                            ID = 5,
                            Arrival = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaxSize = 500,
                            MinSize = 0
                        });
                });

            modelBuilder.Entity("SpaceEngine.Model.Receipt", b =>
                {
                    b.HasOne("SpaceEngine.Parkingspot", "Parkingspot")
                        .WithMany()
                        .HasForeignKey("ParkingspotID");

                    b.Navigation("Parkingspot");
                });
#pragma warning restore 612, 618
        }
    }
}

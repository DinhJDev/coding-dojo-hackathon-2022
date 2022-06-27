﻿// <auto-generated />
using System;
using Hackathon.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackathon.Migrations
{
    [DbContext(typeof(HackathonContext))]
    partial class HackathonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hackathon.Core.HotZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DangerLevel")
                        .HasColumnType("int");

                    b.Property<double?>("Lat")
                        .IsRequired()
                        .HasColumnType("double");

                    b.Property<double?>("Lng")
                        .IsRequired()
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ZoneAge")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("HotZones");
                });

            modelBuilder.Entity("Hackathon.Core.LostFound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Contact")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactType")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("From")
                        .HasColumnType("longtext");

                    b.Property<double?>("Lat")
                        .IsRequired()
                        .HasColumnType("double");

                    b.Property<double?>("Lng")
                        .IsRequired()
                        .HasColumnType("double");

                    b.Property<string>("LostFoundAge")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("LostFounds");
                });

            modelBuilder.Entity("Hackathon.Core.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<double?>("Lat")
                        .IsRequired()
                        .HasColumnType("double");

                    b.Property<double?>("Lng")
                        .IsRequired()
                        .HasColumnType("double");

                    b.Property<string>("SupplyAge")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Supplies");
                });
#pragma warning restore 612, 618
        }
    }
}

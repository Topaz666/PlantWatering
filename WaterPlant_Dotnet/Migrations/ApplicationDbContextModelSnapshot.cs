﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WaterPlant_Dotnet.Data;

namespace WaterPlant_Dotnet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WaterPlant_Dotnet.Models.PlantModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reminder30s")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reminder6h")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("RequireWaitDueAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("RequiredDueAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("WateringAgainDueAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Plant");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace TasksServices.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230109234159_DataBaseStart")]
    partial class DataBaseStart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.MarkerProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt");

                    b.Property<string>("Image");

                    b.Property<bool>("Keyboard");

                    b.Property<double>("Latitude");

                    b.Property<string>("Link");

                    b.Property<double>("Longitude");

                    b.Property<double>("Opacity");

                    b.Property<int>("RiseOffset");

                    b.Property<bool>("RiseOnHover");

                    b.Property<string>("Slope1");

                    b.Property<string>("Slope2");

                    b.Property<string>("Slope3");

                    b.Property<string>("Slope4");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("ZIndexOffset");

                    b.HasKey("Id");

                    b.ToTable("Markers");
                });
#pragma warning restore 612, 618
        }
    }
}
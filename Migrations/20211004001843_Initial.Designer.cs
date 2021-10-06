﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

namespace WebAPI.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20211004001843_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("ContactType");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("WebAPI.Models.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ContactTypes");

                    b.HasData(
                        new { Id = 1, TypeName = "ContactType 1" },
                        new { Id = 2, TypeName = "ContactType 2" },
                        new { Id = 3, TypeName = "ContactType 3" }
                    );
                });

            modelBuilder.Entity("WebAPI.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId");

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ReservationPlace")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}

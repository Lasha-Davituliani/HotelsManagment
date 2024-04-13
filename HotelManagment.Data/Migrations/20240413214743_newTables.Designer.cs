﻿// <auto-generated />
using System;
using HotelManagment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagment.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240413214743_newTables")]
    partial class newTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelManagment.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasAnnotation("Phone", true);

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Nikoloz",
                            LastName = "Chkhartishvili",
                            PersonalNumber = "01024085083",
                            PhoneNumber = "555337681"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Khatia",
                            LastName = "Burduli",
                            PersonalNumber = "01024082203",
                            PhoneNumber = "579057747"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Erekle",
                            LastName = "Davitashvili",
                            PersonalNumber = "12345678947",
                            PhoneNumber = "571058998"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Dali",
                            LastName = "Goderdzishvili",
                            PersonalNumber = "87005633698",
                            PhoneNumber = "555887469"
                        });
                });

            modelBuilder.Entity("HotelManagment.Models.GuestReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("ReservationId");

                    b.ToTable("GuestReservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GuestId = 1,
                            ReservationId = 1
                        },
                        new
                        {
                            Id = 2,
                            GuestId = 2,
                            ReservationId = 1
                        },
                        new
                        {
                            Id = 3,
                            GuestId = 3,
                            ReservationId = 2
                        },
                        new
                        {
                            Id = 4,
                            GuestId = 4,
                            ReservationId = 3
                        });
                });

            modelBuilder.Entity("HotelManagment.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhyisicalAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "თბილისი",
                            Country = "საქართველო",
                            Name = "პირველი სასტუმრო",
                            PhyisicalAddress = "რუსთაველის 4",
                            Rating = 10.0
                        },
                        new
                        {
                            Id = 2,
                            City = "თბილისი",
                            Country = "საქართველო",
                            Name = "მეორე სასტუმრო",
                            PhyisicalAddress = "პეკინის 13",
                            Rating = 8.0
                        },
                        new
                        {
                            Id = 3,
                            City = "ბათუმი",
                            Country = "საქართველო",
                            Name = "მესამე სასტუმრო",
                            PhyisicalAddress = "გამსახურდიას 12",
                            Rating = 7.7000000000000002
                        });
                });

            modelBuilder.Entity("HotelManagment.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "გიორგი",
                            HotelId = 1,
                            LastName = "გიორგაძე"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "თამაზ",
                            HotelId = 2,
                            LastName = "გოდერძიშვილი"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "გიორგი",
                            HotelId = 3,
                            LastName = "გუჯარელიძე"
                        });
                });

            modelBuilder.Entity("HotelManagment.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckInDate = new DateTime(2024, 4, 14, 1, 47, 42, 149, DateTimeKind.Local).AddTicks(7716),
                            CheckOutDate = new DateTime(2024, 4, 24, 1, 47, 42, 149, DateTimeKind.Local).AddTicks(7727)
                        },
                        new
                        {
                            Id = 2,
                            CheckInDate = new DateTime(2024, 4, 14, 1, 47, 42, 149, DateTimeKind.Local).AddTicks(7734),
                            CheckOutDate = new DateTime(2024, 5, 14, 1, 47, 42, 149, DateTimeKind.Local).AddTicks(7735)
                        },
                        new
                        {
                            Id = 3,
                            CheckInDate = new DateTime(2024, 4, 14, 1, 47, 42, 149, DateTimeKind.Local).AddTicks(7755),
                            CheckOutDate = new DateTime(2024, 5, 4, 1, 47, 42, 149, DateTimeKind.Local).AddTicks(7756)
                        });
                });

            modelBuilder.Entity("HotelManagment.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("DailyPrice")
                        .HasColumnType("float");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DailyPrice = 50.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "A-100"
                        },
                        new
                        {
                            Id = 2,
                            DailyPrice = 50.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "A-200"
                        },
                        new
                        {
                            Id = 3,
                            DailyPrice = 50.0,
                            HotelId = 1,
                            IsFree = true,
                            Name = "A-300"
                        },
                        new
                        {
                            Id = 4,
                            DailyPrice = 100.0,
                            HotelId = 1,
                            IsFree = true,
                            Name = "B-100"
                        },
                        new
                        {
                            Id = 5,
                            DailyPrice = 100.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "B-200"
                        },
                        new
                        {
                            Id = 6,
                            DailyPrice = 100.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "B-300"
                        },
                        new
                        {
                            Id = 7,
                            DailyPrice = 200.0,
                            HotelId = 1,
                            IsFree = true,
                            Name = "C-100"
                        },
                        new
                        {
                            Id = 8,
                            DailyPrice = 200.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "C-200"
                        },
                        new
                        {
                            Id = 9,
                            DailyPrice = 200.0,
                            HotelId = 1,
                            IsFree = false,
                            Name = "C-300"
                        },
                        new
                        {
                            Id = 10,
                            DailyPrice = 25.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "100"
                        },
                        new
                        {
                            Id = 11,
                            DailyPrice = 25.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "101"
                        },
                        new
                        {
                            Id = 12,
                            DailyPrice = 25.0,
                            HotelId = 2,
                            IsFree = false,
                            Name = "102"
                        },
                        new
                        {
                            Id = 13,
                            DailyPrice = 50.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "200"
                        },
                        new
                        {
                            Id = 14,
                            DailyPrice = 50.0,
                            HotelId = 2,
                            IsFree = false,
                            Name = "201"
                        },
                        new
                        {
                            Id = 15,
                            DailyPrice = 50.0,
                            HotelId = 2,
                            IsFree = false,
                            Name = "202"
                        },
                        new
                        {
                            Id = 16,
                            DailyPrice = 75.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "300"
                        },
                        new
                        {
                            Id = 17,
                            DailyPrice = 75.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "301"
                        },
                        new
                        {
                            Id = 18,
                            DailyPrice = 75.0,
                            HotelId = 2,
                            IsFree = true,
                            Name = "302"
                        },
                        new
                        {
                            Id = 19,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = false,
                            Name = "A-10"
                        },
                        new
                        {
                            Id = 20,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "A-20"
                        },
                        new
                        {
                            Id = 21,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "A-30"
                        },
                        new
                        {
                            Id = 22,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = false,
                            Name = "B-10"
                        },
                        new
                        {
                            Id = 23,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = false,
                            Name = "B-20"
                        },
                        new
                        {
                            Id = 24,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "B-30"
                        },
                        new
                        {
                            Id = 25,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "C-10"
                        },
                        new
                        {
                            Id = 26,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = false,
                            Name = "C-20"
                        },
                        new
                        {
                            Id = 27,
                            DailyPrice = 150.0,
                            HotelId = 3,
                            IsFree = true,
                            Name = "C-30"
                        });
                });

            modelBuilder.Entity("HotelManagment.Models.GuestReservation", b =>
                {
                    b.HasOne("HotelManagment.Models.Guest", "Guest")
                        .WithMany("GuestReservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagment.Models.Reservation", "Reservation")
                        .WithMany("GuestReservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelManagment.Models.Manager", b =>
                {
                    b.HasOne("HotelManagment.Models.Hotel", "Hotel")
                        .WithOne("Manager")
                        .HasForeignKey("HotelManagment.Models.Manager", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelManagment.Models.Room", b =>
                {
                    b.HasOne("HotelManagment.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelManagment.Models.Guest", b =>
                {
                    b.Navigation("GuestReservations");
                });

            modelBuilder.Entity("HotelManagment.Models.Hotel", b =>
                {
                    b.Navigation("Manager")
                        .IsRequired();

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelManagment.Models.Reservation", b =>
                {
                    b.Navigation("GuestReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
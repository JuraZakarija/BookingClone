﻿// <auto-generated />
using System;
using BookingClone.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingClone.Migrations
{
    [DbContext(typeof(BookingCloneContext))]
    partial class BookingCloneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingClone.Models.Agency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Commission")
                        .HasColumnType("decimal(4,2)");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Agencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Commission = 15.00m,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 773, DateTimeKind.Utc).AddTicks(9158),
                            IsDeleted = false,
                            Name = "Todoric"
                        },
                        new
                        {
                            Id = 2,
                            Commission = 20.00m,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 775, DateTimeKind.Utc).AddTicks(270),
                            IsDeleted = false,
                            Name = "Airbnb"
                        },
                        new
                        {
                            Id = 3,
                            Commission = 23.00m,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 775, DateTimeKind.Utc).AddTicks(293),
                            IsDeleted = false,
                            Name = "Booking"
                        },
                        new
                        {
                            Id = 4,
                            Commission = 17.50m,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 775, DateTimeKind.Utc).AddTicks(294),
                            IsDeleted = false,
                            Name = "Trivago"
                        });
                });

            modelBuilder.Entity("BookingClone.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgencyId");

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("GuestId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int?>("PaymentId");

                    b.Property<int>("RoomId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("GuestId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgencyId = 1,
                            CheckIn = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOut = new DateTime(2019, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 784, DateTimeKind.Utc).AddTicks(384),
                            GuestId = 1,
                            IsDeleted = false,
                            RoomId = 1
                        },
                        new
                        {
                            Id = 2,
                            AgencyId = 2,
                            CheckIn = new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOut = new DateTime(2019, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 784, DateTimeKind.Utc).AddTicks(3478),
                            GuestId = 2,
                            IsDeleted = false,
                            RoomId = 2
                        },
                        new
                        {
                            Id = 3,
                            AgencyId = 3,
                            CheckIn = new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOut = new DateTime(2019, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 784, DateTimeKind.Utc).AddTicks(3562),
                            GuestId = 3,
                            IsDeleted = false,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 4,
                            AgencyId = 4,
                            CheckIn = new DateTime(2019, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOut = new DateTime(2019, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 784, DateTimeKind.Utc).AddTicks(3578),
                            GuestId = 4,
                            IsDeleted = false,
                            RoomId = 4
                        });
                });

            modelBuilder.Entity("BookingClone.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Birthdate");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Gender");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("LastName");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(1987, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 778, DateTimeKind.Utc).AddTicks(7079),
                            Email = "radekoncar@gmail.com",
                            FirstName = "Rade",
                            Gender = "M",
                            IsDeleted = false,
                            LastName = "Končar",
                            PhoneNumber = "0917453456"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1982, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 782, DateTimeKind.Utc).AddTicks(9014),
                            Email = "antemastelic@gmail.com",
                            FirstName = "Ante",
                            Gender = "M",
                            IsDeleted = false,
                            LastName = "Mastelić",
                            PhoneNumber = "0924567484"
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(1991, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 782, DateTimeKind.Utc).AddTicks(9150),
                            Email = "miadimsic@hotmail.com",
                            FirstName = "Mia",
                            Gender = "F",
                            IsDeleted = false,
                            LastName = "Dimšić",
                            PhoneNumber = "0959375035"
                        },
                        new
                        {
                            Id = 4,
                            Birthdate = new DateTime(1982, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 782, DateTimeKind.Utc).AddTicks(9166),
                            Email = "hrvojehorvat@hotmail.com",
                            FirstName = "Hrvoje",
                            Gender = "M",
                            IsDeleted = false,
                            LastName = "Horvat",
                            PhoneNumber = "0983765905"
                        });
                });

            modelBuilder.Entity("BookingClone.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<string>("WebAddress")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Ulica Izidora Kršnjavog 1",
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 776, DateTimeKind.Utc).AddTicks(1792),
                            IsDeleted = false,
                            Name = "Westin",
                            PhoneNumber = "38514892000",
                            WebAddress = "www.westinzagreb.com"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Miramarska Cesta 24",
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 776, DateTimeKind.Utc).AddTicks(3703),
                            IsDeleted = false,
                            Name = "International",
                            PhoneNumber = "38516108800",
                            WebAddress = "www.hotel-international.hr"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Trg Krešimira Ćosića 9",
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 776, DateTimeKind.Utc).AddTicks(3729),
                            IsDeleted = false,
                            Name = "Esplanade",
                            PhoneNumber = "38514566600",
                            WebAddress = "www.esplanade.hr"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Trg Josipa Jurja Strossmayera 10",
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 776, DateTimeKind.Utc).AddTicks(3730),
                            IsDeleted = false,
                            Name = "Palace",
                            PhoneNumber = "38514899600",
                            WebAddress = "www.palace.hr"
                        });
                });

            modelBuilder.Entity("BookingClone.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgencyId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("GuestId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("GuestId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgencyId = 1,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 785, DateTimeKind.Utc).AddTicks(1876),
                            GuestId = 1,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            AgencyId = 2,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 785, DateTimeKind.Utc).AddTicks(3193),
                            GuestId = 2,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            AgencyId = 3,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 785, DateTimeKind.Utc).AddTicks(3218),
                            GuestId = 3,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            AgencyId = 4,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 785, DateTimeKind.Utc).AddTicks(3223),
                            GuestId = 4,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("BookingClone.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("HotelId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("NumberOfBeds");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Size")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Type")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 777, DateTimeKind.Utc).AddTicks(4419),
                            HotelId = 1,
                            IsDeleted = false,
                            NumberOfBeds = 2,
                            PricePerNight = 100.00m,
                            Size = 34.42m,
                            Type = "Double"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 777, DateTimeKind.Utc).AddTicks(7156),
                            HotelId = 2,
                            IsDeleted = false,
                            NumberOfBeds = 2,
                            PricePerNight = 200.00m,
                            Size = 42.12m,
                            Type = "Suite"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 777, DateTimeKind.Utc).AddTicks(7190),
                            HotelId = 3,
                            IsDeleted = false,
                            NumberOfBeds = 4,
                            PricePerNight = 300.00m,
                            Size = 54.66m,
                            Type = "Quad"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2019, 8, 13, 17, 45, 38, 777, DateTimeKind.Utc).AddTicks(7192),
                            HotelId = 4,
                            IsDeleted = false,
                            NumberOfBeds = 4,
                            PricePerNight = 400.00m,
                            Size = 73.81m,
                            Type = "Executive"
                        });
                });

            modelBuilder.Entity("BookingClone.Models.Booking", b =>
                {
                    b.HasOne("BookingClone.Models.Agency", "Agency")
                        .WithMany("Bookings")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BookingClone.Models.Guest", "Guest")
                        .WithMany("Bookings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BookingClone.Models.Payment")
                        .WithMany("Bookings")
                        .HasForeignKey("PaymentId");

                    b.HasOne("BookingClone.Models.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BookingClone.Models.Payment", b =>
                {
                    b.HasOne("BookingClone.Models.Agency", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BookingClone.Models.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BookingClone.Models.Room", b =>
                {
                    b.HasOne("BookingClone.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

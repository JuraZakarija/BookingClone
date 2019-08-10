using System;
using BookingClone.Models;
using Microsoft.EntityFrameworkCore;


namespace BookingClone.Extensions

{
    public static class Seeds
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Agencies(modelBuilder);
            Hotels(modelBuilder);
            Rooms(modelBuilder);
            Guests(modelBuilder);
            Bookings(modelBuilder);
            Payments(modelBuilder);
        }

        public static void Agencies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>().HasData(
                new Agency()
                {
                    Id = 1, 
                    Name = "Todoric", 
                    Commission = 15.00m
                },

                new Agency()
                {
                    Id = 2, 
                    Name = "Airbnb", 
                    Commission = 20.00m
                },

                new Agency()
                { 
                    Id = 3, 
                    Name = "Booking", 
                    Commission = 23.00m 
                },

                new Agency()
                { 
                    Id = 4, 
                    Name = "Trivago", 
                    Commission = 17.50m
                }
            );
        }

        public static void Bookings(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
                new Booking()
                { 
                    Id = 1, 
                    AgencyId = 1,
                    PaymentId = 1, 
                    RoomId = 1, 
                    GuestId = 1, 
                    CheckIn = DateTime.Parse("2019-01-01"), 
                    CheckOut = DateTime.Parse("2019-01-08")
                },

                new Booking()
                { 
                    Id = 2, 
                    AgencyId = 2,
                    PaymentId = 2, 
                    RoomId = 2, 
                    GuestId = 2, 
                    CheckIn = DateTime.Parse("2019-02-01"), 
                    CheckOut = DateTime.Parse("2019-02-08")
                },

                new Booking()
                { 
                    Id = 3, 
                    AgencyId = 3, 
                    PaymentId = 3, 
                    RoomId = 3, 
                    GuestId = 3, 
                    CheckIn = DateTime.Parse("2019-03-01"), 
                    CheckOut = DateTime.Parse("2019-03-08")
                },

                new Booking()
                { 
                    Id = 4, 
                    AgencyId = 4, 
                    PaymentId = 4, 
                    RoomId = 4, 
                    GuestId = 4,
                    CheckIn = DateTime.Parse("2019-04-01"), 
                    CheckOut = DateTime.Parse("2019-04-08")
                }
            );
        }

        public static void Guests(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(
                new Guest()
                { 
                    Id = 1, 
                    FirstName = "Rade", 
                    LastName = "Končar", 
                    Gender = "M"
                },
                
                new Guest()
                { 
                    Id = 2, 
                    FirstName = "Ante", 
                    LastName = "Mastelić", 
                    Gender = "M"
                },

                new Guest()
                { 
                    Id = 3, 
                    FirstName = "Mia", 
                    LastName = "Dimšić", 
                    Gender = "F"
                },

                new Guest()
                { 
                    Id = 4, 
                    FirstName = "Hrvoje", 
                    LastName = "Horvat", 
                    Gender = "M"
                }
            );
        }

        public static void Hotels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel()
                { 
                    Id = 1, 
                    Name = "Westin", 
                    Address = "Ulica Izidora Kršnjavog 1",
                    WebAddress = "www.westinzagreb.com", 
                    PhoneNumber = "38514892000" 
                },

                new Hotel()
                { 
                    Id = 2, 
                    Name = "International", 
                    Address = "Miramarska Cesta 24",
                    WebAddress = "www.hotel-international.hr", 
                    PhoneNumber = "38516108800"
                },

                new Hotel()
                { 
                    Id = 3, 
                    Name = "Esplanade", 
                    Address = "Trg Krešimira Ćosića 9",
                    WebAddress = "www.esplanade.hr", 
                    PhoneNumber = "38514566600"
                },

                new Hotel()
                { 
                    Id = 4, 
                    Name = "Palace", 
                    Address = "Trg Josipa Jurja Strossmayera 10",
                    WebAddress = "www.palace.hr", 
                    PhoneNumber = "38514899600"
                }
            );
        }

        public static void Payments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasData(
                new Payment()
                {
                    Id = 1, 
                    Margin = 25.00m
                },

                new Payment()
                {
                    Id = 2, 
                    Margin = 40.00m
                },

                new Payment()
                {
                    Id = 3,
                    Margin = 20.00m 
                },

                new Payment()
                {
                    Id = 4, 
                    Margin = 35.00m
                } 
            );
        }

        public static void Rooms(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room()
                {
                    Id = 1, 
                    HotelId = 1, 
                    Size = 34.42m, 
                    NumberOfBeds = 2, 
                    Type = "Double",
                    PricePerNight = 100.00m,
                },

                new Room()
                { 
                    Id = 2, 
                    HotelId = 2, 
                    Size = 42.12m, 
                    NumberOfBeds = 2, 
                    Type = "Suite",
                    PricePerNight = 200.00m,
                },

                new Room()
                { 
                    Id = 3, 
                    HotelId = 3, 
                    Size = 54.66m, 
                    NumberOfBeds = 4, 
                    Type = "Quad",
                    PricePerNight = 300.00m,
                },

                new Room()
                { 
                    Id = 4, 
                    HotelId = 4, 
                    Size = 73.81m, 
                    NumberOfBeds = 4, 
                    Type = "Executive",
                    PricePerNight = 400.00m,
                }
            );
        }
    }
}


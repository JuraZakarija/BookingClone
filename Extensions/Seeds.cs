using System;
using BookingClone.Models;
using Microsoft.AspNetCore.Identity;
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
            AuthUsers(modelBuilder);
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
                    RoomId = 1, 
                    UserId = 1, 
                    CheckIn = DateTime.Parse("2019-01-01"), 
                    CheckOut = DateTime.Parse("2019-01-08")
                },

                new Booking()
                { 
                    Id = 2, 
                    AgencyId = 2,
                    RoomId = 2, 
                    UserId = 2, 
                    CheckIn = DateTime.Parse("2019-02-01"), 
                    CheckOut = DateTime.Parse("2019-02-08")
                },

                new Booking()
                { 
                    Id = 3, 
                    AgencyId = 3, 
                    RoomId = 3, 
                    UserId = 3, 
                    CheckIn = DateTime.Parse("2019-03-01"), 
                    CheckOut = DateTime.Parse("2019-03-08")
                },

                new Booking()
                { 
                    Id = 4, 
                    AgencyId = 4,
                    RoomId = 4, 
                    UserId = 4,
                    CheckIn = DateTime.Parse("2019-04-01"), 
                    CheckOut = DateTime.Parse("2019-04-08")
                }
            );
        }

        public static void AuthUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<AuthUser>();
            var password = hasher.HashPassword(null, "1A1errrr");
            modelBuilder.Entity<AuthUser>().HasData(
                new AuthUser()
                { 
                    Id = 1, 
                    FirstName = "Rade", 
                    LastName = "Končar", 
                    Birthdate = DateTime.Parse("1987-06-11"), 
                    Gender = "M",
                    PhoneNumber = "0917453456",
                    Email = "radekoncar@gmail.com",
                    PasswordHash = password
                },
                
                new AuthUser()
                { 
                    Id = 2, 
                    FirstName = "Ante", 
                    LastName = "Mastelić",
                    Birthdate = DateTime.Parse("1982-03-22"),                      
                    Gender = "M",
                    PhoneNumber = "0924567484",
                    Email = "antemastelic@gmail.com",
                    PasswordHash = password
                },

                new AuthUser()
                { 
                    Id = 3, 
                    FirstName = "Mia", 
                    LastName = "Dimšić", 
                    Birthdate = DateTime.Parse("1991-02-11"),                      
                    Gender = "F",
                    PhoneNumber = "0959375035",
                    Email = "miadimsic@hotmail.com",
                    PasswordHash = password
                },

                new AuthUser()
                { 
                    Id = 4, 
                    FirstName = "Hrvoje", 
                    LastName = "Horvat", 
                    Birthdate = DateTime.Parse("1982-09-13"),
                    Gender = "M",
                    PhoneNumber = "0983765905",
                    Email = "hrvojehorvat@hotmail.com",
                    PasswordHash = password
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
                    AgencyId = 1,
                    UserId = 1 
                },

                new Payment()
                {
                    Id = 2,
                    AgencyId = 2,
                    UserId = 2 
                },

                new Payment()
                {
                    Id = 3,
                    AgencyId = 3,
                    UserId = 3
                },

                new Payment()
                {
                    Id = 4,
                    AgencyId = 4,
                    UserId = 4 
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
                    RoomNumber = "101",
                    PricePerNight = 100.00m,
                },

                new Room()
                { 
                    Id = 2, 
                    HotelId = 2, 
                    Size = 42.12m, 
                    NumberOfBeds = 2, 
                    Type = "Suite",
                    RoomNumber = "202",
                    PricePerNight = 200.00m,
                },

                new Room()
                { 
                    Id = 3, 
                    HotelId = 3, 
                    Size = 54.66m, 
                    NumberOfBeds = 4, 
                    Type = "Quad",
                    RoomNumber = "301",
                    PricePerNight = 300.00m,
                },

                new Room()
                { 
                    Id = 4, 
                    HotelId = 4, 
                    Size = 73.81m, 
                    NumberOfBeds = 4, 
                    Type = "Executive",
                    RoomNumber = "202",
                    PricePerNight = 400.00m,
                },
                
                new Room()
                {
                    Id = 5, 
                    HotelId = 1, 
                    Size = 33.77m, 
                    NumberOfBeds = 2, 
                    Type = "Double",
                    RoomNumber = "102",
                    PricePerNight = 100.00m,
                },

                new Room()
                { 
                    Id = 6, 
                    HotelId = 2, 
                    Size = 36.46m, 
                    NumberOfBeds = 2, 
                    Type = "Suite",
                    RoomNumber = "204",
                    PricePerNight = 200.00m,
                },

                new Room()
                { 
                    Id = 7, 
                    HotelId = 3, 
                    Size = 65.45m, 
                    NumberOfBeds = 4, 
                    Type = "Quad",
                    RoomNumber = "304",
                    PricePerNight = 300.00m,
                },

                new Room()
                { 
                    Id = 8, 
                    HotelId = 4, 
                    Size = 75.64m, 
                    NumberOfBeds = 4, 
                    Type = "Executive",
                    RoomNumber = "206",
                    PricePerNight = 400.00m,
                },

                new Room()
                {
                    Id = 9, 
                    HotelId = 1, 
                    Size = 43.46m, 
                    NumberOfBeds = 2, 
                    Type = "Double",
                    RoomNumber = "103",
                    PricePerNight = 100.00m,
                },

                new Room()
                { 
                    Id = 10, 
                    HotelId = 2, 
                    Size = 34.64m, 
                    NumberOfBeds = 2, 
                    Type = "Suite",
                    RoomNumber = "206",
                    PricePerNight = 200.00m,
                },

                new Room()
                { 
                    Id = 11, 
                    HotelId = 3, 
                    Size = 53.66m, 
                    NumberOfBeds = 4, 
                    Type = "Quad",
                    RoomNumber = "305",
                    PricePerNight = 300.00m,
                },

                new Room()
                { 
                    Id = 12, 
                    HotelId = 4, 
                    Size = 79.45m, 
                    NumberOfBeds = 4, 
                    Type = "Executive",
                    RoomNumber = "208",
                    PricePerNight = 400.00m,
                }
            );
        }
    }
}


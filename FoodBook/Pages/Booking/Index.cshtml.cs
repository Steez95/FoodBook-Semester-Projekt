using System;
using FoodBook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IO;

namespace FoodBook.Booking.Index
{
    public class IndexModel : PageModel
    {
        private readonly Tables _bookings;
        public List<Table> TablesList { get; set; }

        public IndexModel(Tables bookings)
        {
            _bookings = bookings;

            TablesList = new List<Table>() 
            { 
                new Table
                {
                    TableNumber = 1,
                    TableSize = 3,
                    Customer = null,
                    IsBooked = false,
                },
                new Table
                {
                    TableNumber = 2,
                    TableSize = 5,
                    Customer = null,
                    IsBooked = false,
                },
                new Table
                {
                    TableNumber = 3,
                    TableSize = 2,
                    Customer = null,
                    IsBooked = false,
                },
                new Table
                {
                    TableNumber = 4,
                    TableSize = 10,
                    Customer = null,
                    IsBooked = false,
                },
                new Table
                {
                    TableNumber = 5,
                    TableSize = 4,
                    Customer = null,
                    IsBooked = false,
                },
                new Table
                {
                    TableNumber = 6,
                    TableSize = 3,
                    Customer = null,
                    IsBooked = false,
                },
                new Table
                {
                    TableNumber = 7,
                    TableSize = 5,
                    Customer = null,
                    IsBooked = false,
                },
                new Table
                {
                    TableNumber = 8,
                    TableSize = 4,
                    Customer = new Kunde
                    {
                        Id = 1,
                        Email = "hej@yeet.dk",
                        Name = "Jørgen Skolemand",
                        Phone = "88888888"
                    },
                    IsBooked = true,
                }, 
            };
        }

        public void OnPost(string tableNumber)
        {
            if (int.TryParse(tableNumber, out int tableNum) && _bookings.AvailableTables.ContainsKey(tableNum) && !_bookings.AvailableTables[tableNum].IsBooked)
            {
                _bookings.AvailableTables[tableNum].IsBooked = true;

                // Save bookings to the JSON file
                SaveBookings();
            }
        }

        private void SaveBookings()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "bookings.json");
            var json = JsonConvert.SerializeObject(_bookings.AvailableTables, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
          
        }
    }
}

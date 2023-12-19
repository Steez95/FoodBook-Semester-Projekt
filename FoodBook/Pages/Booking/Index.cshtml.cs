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

        public List<Table> TablesList { get; set; }

        public IndexModel()
        {


            LoadTables();

        }

        public void OnPost(string tableNumber, Kunde customer)
        {
            if (int.TryParse(tableNumber, out int tableNum) && TablesList.Exists(t => t.TableNumber == tableNum) 
                && !TablesList.Find(t => t.TableNumber == tableNum).IsBooked)
            {
                var table = TablesList.Find(t => t.TableNumber == tableNum);
                table.IsBooked = true;
                table.Customer = customer;
                table.Customer.Id = 1;

                // Save tables to the JSON file
                SaveTables();
            }
        }

        private void SaveTables()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "bookings.json");
            var json = JsonConvert.SerializeObject(TablesList, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);
        }

        private void LoadTables()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "bookings.json");

            if (System.IO.File.Exists(filePath))
            {
                var json = System.IO.File.ReadAllText(filePath);
                TablesList = JsonConvert.DeserializeObject<List<Table>>(json);
            }
            else
            {
                // If the file doesn't exist, create an empty list
                TablesList = new List<Table>();
            }
        }
    }
}

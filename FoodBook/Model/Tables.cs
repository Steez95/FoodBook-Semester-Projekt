namespace FoodBook.Model
{
    public class Tables
    {
        public Dictionary<int, Booking> AvailableTables { get; set; } = new Dictionary<int, Booking>
        {
            { 1, new Booking { TableNumber = 1, IsBooked = false } },
            { 2, new Booking { TableNumber = 2, IsBooked = false } },
            { 3, new Booking { TableNumber = 3, IsBooked = false } },
            { 4, new Booking { TableNumber = 4, IsBooked = false } },
            { 5, new Booking { TableNumber = 5, IsBooked = false } },
            { 6, new Booking { TableNumber = 6, IsBooked = false } },
            { 7, new Booking { TableNumber = 7, IsBooked = false } },
            { 8, new Booking { TableNumber = 8, IsBooked = false } },
            { 9, new Booking { TableNumber = 9, IsBooked = false } }
        };
    }
}

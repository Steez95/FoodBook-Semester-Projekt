namespace FoodBook.Model
{
    public class Table
    {
        public int TableNumber { get; set; }
        public int TableSize { get; set; }
        public bool IsBooked { get; set; }
        public Kunde Customer { get; set; }

    }
}

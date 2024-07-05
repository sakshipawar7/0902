using System.Text.Json.Serialization;
namespace WebApplication1.Models
{
    public class BookModel0902
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }
        public string Edition { get; set; }
        public int YearOfPublishing { get; set; }
        public double Rating { get; set; }
    }
}

namespace webapi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Rating { get; set; }
    }
}

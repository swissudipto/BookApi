using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookApi.Model
{
    public class Book
    {
        public Book()
        {
            this.PublicationDate  = DateTime.Now;
        }
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public DateTime PublicationDate { get; set; } 
    }
}
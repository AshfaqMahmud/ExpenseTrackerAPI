using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        [BsonElement("amount")]
        public decimal Amount { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [BsonElement("category")]
        public string Category { get; set; }
        
       
    }
}
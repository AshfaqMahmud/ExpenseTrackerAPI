using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; } = null!;

        [BsonElement("description")]
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}
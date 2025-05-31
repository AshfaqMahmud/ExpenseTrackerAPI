using System;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using System.Collections.Generic;


namespace ExpenseTracker.Models
{
    public class Stock
    {
        [BsonId]        // this attribute indicates that this property is the primary key
        [BsonRepresentation(BsonType.ObjectId)]     // this attribute indicates that the property is stored as an ObjectId in MongoDB
        public string? Id
        {
            get ;set ;
        }
        // Add properties here
        public string Symbol { get; set; } = string.Empty;
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }

        public decimal LastDiv { get; set; }
        public string Industry { get; set; }

        public long MarketCap { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
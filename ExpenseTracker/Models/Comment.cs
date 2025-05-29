﻿namespace ExpenseTracker.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? StockId { get; set; }
        public Stock? Stock { get; set; }
    }
}
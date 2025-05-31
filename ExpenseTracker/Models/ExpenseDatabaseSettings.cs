namespace ExpenseTracker.Models
{
    public class ExpenseDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string ExpensesCollectionName { get; set; } = string.Empty;
    }
}
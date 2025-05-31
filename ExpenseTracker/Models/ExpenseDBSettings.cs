namespace ExpenseTracker.Models;

public class ExpenseDBSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public string ExpenseCollectionName { get; set; }
}
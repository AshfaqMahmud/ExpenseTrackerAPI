using ExpenseTracker.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ExpenseTracker.Services;

public class ExpenseService
{
    private readonly IMongoCollection<Stock> _expenses;

    public ExpenseService(IOptions<ExpenseDatabaseSettings> expenseDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            expenseDatabaseSettings.Value.ConnectionString
        );

        var mongoDatabase = mongoClient.GetDatabase(
            expenseDatabaseSettings.Value.DatabaseName
        );

        _expenses = mongoDatabase.GetCollection<Stock>(
            expenseDatabaseSettings.Value.ExpensesCollectionName
        );
    }

    public async Task<List<Stock>> GetAsync() =>
        await _expenses.Find(_ => true).ToListAsync();

    public async Task<Stock?> GetAsyncbyId(string id) =>
        await _expenses.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Stock newExpense) =>
        await _expenses.InsertOneAsync(newExpense);

    public async Task UpdateAsync(string id, Stock updatedExpense=null) =>
        await _expenses.ReplaceOneAsync(x => x.Id == id, updatedExpense);

    public async Task RemoveAsync(string id) =>
        await _expenses.DeleteOneAsync(x => x.Id == id);
}
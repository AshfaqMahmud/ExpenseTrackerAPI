//using ExpenseTracker.Models;
//using Microsoft.Extensions.Options;
//using MongoDB.Driver;


//namespace ExpenseTracker.Services
//{
//    public class ExpenseService
//    {
//        private readonly IMongoCollection<Expense> _expenses;

//        public ExpenseService(
//            IOptions<ExpenseDBSettings> settings)
//        {
//            if (string.IsNullOrWhiteSpace(settings.Value.ExpenseCollectionName))
//                throw new ArgumentException("ExpenseCollectionName must be provided in configuration.", nameof(settings.Value.ExpenseCollectionName));

//            var mongoClient = new MongoClient(settings.Value.ConnectionString);
//            var mongoDB = mongoClient.GetDatabase(settings.Value.DatabaseName);
//            _expenses = mongoDB.GetCollection<Expense>(settings.Value.ExpenseCollectionName);
//        }


//        public async Task<List<Expense>> GetAsync() =>
//            await _expenses.Find(expense => true).ToListAsync();

//        public async Task<Expense?> GetAsync(string id) =>
//            await _expenses.Find(expense => expense.Id == id).FirstOrDefaultAsync();

//        public async Task CreateAsync(Expense expense) =>
//            await _expenses.InsertOneAsync(expense).ContinueWith(_ => expense);

//        public async Task UpdateAsync(string id, Expense expenseIn) =>
//             await _expenses.ReplaceOneAsync(expense => expense.Id == id, expenseIn);

//        public async Task RemoveAsync(string id) =>
//            await _expenses.DeleteOneAsync(expense => expense.Id == id);


//    }
//}

using ExpenseTracker.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private readonly IMongoCollection<Expense> _expenses;

        public ExpenseService(IMongoDatabase database)
        {
            _expenses = database.GetCollection<Expense>("Expenses");
        }

        public List<Expense> Get() =>
            _expenses.Find(expense => true).ToList();

        public Expense Get(string id) =>
            _expenses.Find<Expense>(expense => expense.Id == id).FirstOrDefault();

        public Expense Create(Expense expense)
        {
            _expenses.InsertOne(expense);
            return expense;
        }

        public void Update(string id, Expense expenseIn) =>
            _expenses.ReplaceOne(expense => expense.Id == id, expenseIn);

        public void Remove(string id) =>
            _expenses.DeleteOne(expense => expense.Id == id);
    }
}


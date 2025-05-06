using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Expenses
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            // Instead of CreatedAtAction, directly return the response with 201 Created and the new Expense
            return CreatedAtRoute("GetExpenseById", new { id = expense.ExpenseId }, expense);
        }

        // GET: api/Expenses/{id}
        [HttpGet("{id}", Name = "GetExpenseById")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }


        // GET: api/Expenses/{userId}/monthly/{month}
        [HttpGet("{userId}/monthly/{month}")]
        public async Task<ActionResult<IEnumerable<Expense>>> GetMonthlyExpenses(int userId, int month)
        {
            var expenses = await _context.Expenses
                .Where(e => e.UserId == userId && e.Date.Month == month)
                .ToListAsync();

            if (expenses == null)
            {
                return NotFound();
            }

            return expenses;
        }

        // GET: api/Expenses/{userId}/yearly/{year}
        [HttpGet("{userId}/yearly/{year}")]
        public async Task<ActionResult<IEnumerable<Expense>>> GetYearlyExpenses(int userId, int year)
        {
            var expenses = await _context.Expenses
                .Where(e => e.UserId == userId && e.Date.Year == year)
                .ToListAsync();

            if (expenses == null)
            {
                return NotFound();
            }

            return expenses;
        }
    }
}

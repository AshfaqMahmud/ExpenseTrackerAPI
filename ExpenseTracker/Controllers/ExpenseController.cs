using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpensesController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public ActionResult<List<Expense>> Get() =>
            _expenseService.Get();

        [HttpGet("{id:length(24)}", Name = "GetExpense")]
        public ActionResult<Expense> Get(string id)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
                return NotFound();

            return expense;
        }

        [HttpPost]
        public ActionResult<Expense> Create(Expense expense)
        {
            _expenseService.Create(expense);

            // Corrected CreatedAtRoute call
            return CreatedAtRoute("GetExpense", new { id = expense.Id }, expense);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Expense expenseIn)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
            {
                return NotFound();
            }

            // Ensure we don't modify the ID
            expenseIn.Id = id; // Set the ID from the route parameter

            _expenseService.Update(id, expenseIn);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
                return NotFound();

            _expenseService.Remove(id);
            return NoContent();
        }
    }
}
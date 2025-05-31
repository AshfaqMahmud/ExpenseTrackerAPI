//using ExpenseTracker.Models;
//using ExpenseTracker.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace ExpenseTracker.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ExpenseController : ControllerBase
//    {
//        private readonly ExpenseService _expenseService;

//        public ExpenseController(ExpenseService expenseService) =>
//            _expenseService = expenseService;

//        [HttpGet]
//        public async Task<List<Expense>> Get() =>
//            await _expenseService();

//        [HttpGet("{id:length(24)}")]
//        public async Task<ActionResult<Expense>> Get(string id)
//        {
//            var expense = await _expenseService.GetAsync(id);
//            if (expense is null)
//            {
//                return NotFound();
//            }
//            return expense;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post(Expense newExpense)
//        {
//            await _expenseService.CreateAsync(newExpense);
//            return CreatedAtAction(nameof(Get), new { id = newExpense.Id }, newExpense);
//        }

//        [HttpPut("{id:length(24)}")]
//        public async Task<IActionResult> Update(string id, Expense updatedExpense)
//        {
//            var expense = await _expenseService.GetAsync(id);
//            if (expense is null)
//            {
//                return NotFound();
//            }
//            updatedExpense.Id = expense.Id;
//            await _expenseService.UpdateAsync(id, updatedExpense);
//            return NoContent();
//        }

//        [HttpDelete("{id:length(24)}")]
//        public async Task<IActionResult> Delete(string id)
//        {
//            var expense = await _expenseService.GetAsync(id);
//            if (expense is null)
//            {
//                return NotFound();
//            }
//            await _expenseService.RemoveAsync(id);
//            return NoContent();
//        }
//    }
//}

using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return CreatedAtRoute("GetExpense", expense);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Expense expenseIn)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
                return NotFound();

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


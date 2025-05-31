using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly ExpenseService _stockService;

        public StocksController(ExpenseService stockService) =>
            _stockService = stockService;

        [HttpGet]
        public async Task<IEnumerable<Stock>> Get() =>
            await _stockService.GetAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Stock>> Get(string id)
        {
            var stock = await _stockService.GetAsyncbyId(id);

            if (stock is null)
            {
                return NotFound();
            }

            return stock;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Stock newStock)
        {
            await _stockService.CreateAsync(newStock);

            return CreatedAtAction(nameof(Get), new { id = newStock.Id }, newStock);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(string id, Stock updatedStock)
        {
            var stock = await _stockService.GetAsyncbyId(id);

            if (stock is null)
            {
                return NotFound();
            }

            updatedStock.Id = stock.Id;

            //var result = await _stockService.UpdateAsync("2", updatedStock);

            // if (!result)
            // {
            //     return BadRequest();
            // }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(string id)
        {
            var stock = await _stockService.GetAsyncbyId(id);

            if (stock is null)
            {
                return NotFound();
            }

            await _stockService.RemoveAsync(id);

            return NoContent();
        }
    }
}

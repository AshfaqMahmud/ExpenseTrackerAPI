using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            var stocks = _context.Stock.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetStockById([FromRoute]int id)
        {
            var stock = _context.Stock.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
    }
}
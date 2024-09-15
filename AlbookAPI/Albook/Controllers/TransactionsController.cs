using Albook.Models.Domain;
using Albook.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Albook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        [Authorize(Roles = "Reader,Admin")]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            await _transactionService.AddTransactionAsync(transaction);
            return Ok(new { message = "Transaction completed successfully." });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Reader,Admin")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }
    }
}

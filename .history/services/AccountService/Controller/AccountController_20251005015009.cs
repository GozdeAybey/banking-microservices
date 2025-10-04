using AccountService.Data;
using AccountService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountDbContext _context;

        public AccountController(AccountDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            account.Id = Guid.NewGuid();
            account.CreatedAt = DateTime.UtcNow;

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = account.Id }, account);
        }

        [HttpPost("{id}/deposit")]
        public async Task<IActionResult> Deposit(Guid id, [FromQuery] decimal amount)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();

            account.Balance += amount;
            await _context.SaveChangesAsync();

            return Ok(account);
        }

        [HttpPost("{id}/withdraw")]
        public async Task<IActionResult> Withdraw(Guid id, [FromQuery] decimal amount)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();
            if (account.Balance < amount) return BadRequest("Insufficient balance");

            account.Balance -= amount;
            await _context.SaveChangesAsync();

            return Ok(account);
        }
    }
}
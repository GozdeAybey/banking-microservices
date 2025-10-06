using Microsoft.AspNetCore.Mvc;
using TransactionService.Data;
using TransactionService.Models;

namespace TransactionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionLogRepository _repo;

        public TransactionController(TransactionLogRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("log")]
        public async Task<IActionResult> CreateLog([FromBody] TransactionLog log)
        {
            await _repo.AddLogAsync(log);
            return Ok(log);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLogs()
        {
            var logs = await _repo.GetAllLogsAsync();
            return Ok(logs);
        }
    }
}
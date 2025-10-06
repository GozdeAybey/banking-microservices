using MongoDB.Driver;
using TransactionService.Models;
using TransactionService.Settings;
using Microsoft.Extensions.Options;

namespace TransactionService.Data
{
    public class TransactionLogRepository
    {
        private readonly IMongoCollection<TransactionLog> _collection;

        public TransactionLogRepository(IMongoDatabase database, IOptions<MongoDbSettings> options)
        {
            _collection = database.GetCollection<TransactionLog>(options.Value.CollectionName);
        }

        public async Task AddLogAsync(TransactionLog log)
        {
            await _collection.InsertOneAsync(log);
        }

        public async Task<List<TransactionLog>> GetAllLogsAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}
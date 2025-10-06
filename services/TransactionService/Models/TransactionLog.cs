using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TransactionService.Models
{
    public class TransactionLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public Guid AccountId { get; set; }
        public string OperationType { get; set; } = string.Empty; // Deposit / Withdraw
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
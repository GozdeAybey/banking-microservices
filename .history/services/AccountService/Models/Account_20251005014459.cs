using System;

namespace AccountService.Models
{
    public class Account
    {
        public Guid Id { get; set; }          // Primary Key
        public string Name { get; set; }      // Hesap sahibi adı
        public decimal Balance { get; set; }  // Mevcut bakiye
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

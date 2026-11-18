using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public sealed class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public Currency Currency {  get; set; }
        public TransactionStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}

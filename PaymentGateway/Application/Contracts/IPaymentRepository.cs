using Domain.Enums;
using Domain.Models;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface IPaymentRepository
    {
        Task CreateTransactionAsync(Transaction transaction);
        Task SaveChangesAsync();
    }
}

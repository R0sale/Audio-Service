using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts;
using Domain.Enums;
using Domain.Models;
using Domain.Shared;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _context;

        public PaymentRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);

            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

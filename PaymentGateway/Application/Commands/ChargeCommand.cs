using Application.Contracts;
using Domain.Enums;
using Domain.Models;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Application.Commands
{
    public record ChargeCommand(Guid UserId, decimal Amount, Currency Currency, string IdempotencyKey) : IRequest<Result>;

    public class ChargeCommandHandler : IRequestHandler<ChargeCommand, Result>
    {
        private readonly IPaymentRepository _paymentRepository;

        public ChargeCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Result> Handle(ChargeCommand request, CancellationToken ct)
        {
            try
            {
                var transaction = new Transaction()
                {
                    Status = TransactionStatus.Pending,
                    Currency = request.Currency,
                    Amount = request.Amount,
                    UserId = request.UserId,
                };

                await _paymentRepository.CreateTransactionAsync(transaction);

                bool result = true;

                transaction.Status = result ? TransactionStatus.Success : TransactionStatus.Failed;

                await _paymentRepository.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception)
            {
                return Result.Failure($"Couldn't charge money {request.Amount}{request.Currency} from user {request.UserId}");
            }
        }
    }
}

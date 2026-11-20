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
    public record ChargeCommand(Guid UserId, decimal Amount, Currency Currency, string PaymentMethodId, string IdempotencyKey) : IRequest<Result<TransactionStatus>>;

    public class ChargeCommandHandler : IRequestHandler<ChargeCommand, Result<TransactionStatus>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentProvider _paymentProvider;

        public ChargeCommandHandler(IPaymentRepository paymentRepository, IPaymentProvider paymentProvider)
        {
            _paymentRepository = paymentRepository;
            _paymentProvider = paymentProvider;
        }

        public async Task<Result<TransactionStatus>> Handle(ChargeCommand request, CancellationToken ct)
        {
            try
            {
                var record = await _paymentRepository.GetTransactionByIdempotencyKeyAsync(request.IdempotencyKey);

                if (record != null)
                    return Result<TransactionStatus>.Success(record.Status);

                var transaction = new Transaction()
                {
                    Status = TransactionStatus.Pending,
                    Currency = request.Currency,
                    Amount = request.Amount,
                    UserId = request.UserId,
                    IdempotencyKey = request.IdempotencyKey,
                };

                

                await _paymentRepository.CreateTransactionAsync(transaction);

                var result = await _paymentProvider.ChargeAsync(request.Amount, request.Currency, request.PaymentMethodId, request.IdempotencyKey, ct);

                if (!result.IsSuccessful)
                {
                    transaction.Status = TransactionStatus.Failed;
                    transaction.ErrorMessage = result.Error;
                    transaction.PaymentIntentId = result.PaymentIntentId;

                    await _paymentRepository.SaveChangesAsync();

                    return Result<TransactionStatus>.Failure(result.Error);
                }

                transaction.Status = TransactionStatus.Success;
                transaction.PaymentIntentId = result.PaymentIntentId;

                await _paymentRepository.SaveChangesAsync();

                return Result<TransactionStatus>.Success(transaction.Status);
            }
            catch (Exception)
            {
                return Result<TransactionStatus>.Failure($"Couldn't charge money {request.Amount}{request.Currency} from user {request.UserId}");
            }
        }
    }
}

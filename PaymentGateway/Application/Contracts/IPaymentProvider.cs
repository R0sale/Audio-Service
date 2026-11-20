using Domain.Enums;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface IPaymentProvider
    {
        Task<PaymentResult> ChargeAsync(decimal amountInDollars, Currency currency, string paymentMethodId, string IdempotencyKey, CancellationToken ct);
    }
}

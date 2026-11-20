using Application.Contracts;
using Domain.Enums;
using Domain.Shared;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.BillingPortal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Providers
{
    public class StripeProvider : IPaymentProvider
    {
        private const string Success = "succeeded";
        private readonly IStripeClient _client;

        public StripeProvider(IStripeClient client)
        {
            _client = client;
        }

        public async Task<PaymentResult> ChargeAsync(decimal amountInDollars, Currency currency, string paymentMethodId, string IdempotencyKey, CancellationToken ct)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amountInDollars * 100),
                Currency = currency.ToString().ToLowerInvariant(),
                PaymentMethod = paymentMethodId,
                Confirm = true,
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                    AllowRedirects = "never"
                }
            };

            var service = new PaymentIntentService(_client);

            try
            {
                var requestOptions = new RequestOptions { IdempotencyKey = IdempotencyKey };
                var paymentIntent = await service.CreateAsync(options, requestOptions, ct);

                if (paymentIntent.Status == Success)
                    return PaymentResult.Success(paymentIntent.Id);
                else
                    return PaymentResult.Failure($"The payment with paymentId {paymentIntent.Id} ended with status {paymentIntent.Status}", paymentIntent.Id);
            }
            catch (StripeException ex)
            {
                return PaymentResult.Failure(ex.Message, ex.StripeError.PaymentIntent.Id);
            }
        }
    }
}

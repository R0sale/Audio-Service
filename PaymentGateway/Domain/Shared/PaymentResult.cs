using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Shared
{
    public class PaymentResult
    {
        public bool IsSuccessful { get; }
        public string Error { get; }
        public string PaymentIntentId { get; }

        public PaymentResult(bool isSuccessful, string error, string paymentIntentId)
        {
            IsSuccessful = isSuccessful;
            Error = error;
            PaymentIntentId = paymentIntentId;
        }

        public static PaymentResult Success(string paymentIntentId) => new PaymentResult(true, string.Empty, paymentIntentId);
        public static PaymentResult Failure(string error, string paymentIntentId) => new PaymentResult(false, error, paymentIntentId);
    }
}

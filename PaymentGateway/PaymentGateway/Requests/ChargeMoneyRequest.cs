using Domain.Enums;

namespace PaymentGateway.Requests
{
    public sealed class ChargeMoneyRequest
    {
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
    }
}

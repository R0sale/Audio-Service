using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Requests;

namespace PaymentGateway.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("charge")]
        public async Task<IActionResult> ChargeMoney([FromBody] ChargeMoneyRequest request, [FromHeader(Name = "Idempotency-Key")] string IdempotencyKey)
        {
            var command = new ChargeCommand(request.UserId, request.Amount, request.Currency, request.PaymentMethodId, IdempotencyKey);
            var result = await _mediator.Send(command);

            if (result.IsSuccessful)
                return Ok(result.Value);
            else
                return BadRequest(result.Error);
        }
    }
}

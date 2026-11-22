using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AudioService.Api.Controllers
{
    [ApiController]
    [Route("api/tracks")]
    public class TracksController : ControllerBase
    {
        private readonly ITracksService _tracksService;

        public TracksController(ITracksService tracksService)
        {
            _tracksService = tracksService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTrackById(Guid id)
        {
            var result = await _tracksService.GetTrackByIdAsync(id, HttpContext.RequestAborted);

            if (!result.IsSuccessful)
                return NotFound(result.ErrorMessage);

            return Ok(result.Value);
        }
    }
}

using Application.Contracts;
using Domain.Shared;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AudioService.Api.Controllers
{
    [ApiController]
    [Route("api/audio")]
    public class AudioController : ControllerBase
    {
        private readonly IAudioService _service;

        public AudioController(IAudioService service)
        {
            _service = service;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTrackById(Guid id)
        {
            var result = await _service.GetTrackByIdAsync(id, HttpContext.RequestAborted);

            if (!result.IsSuccessful)
                return NotFound(result.ErrorMessage);
            
            return Ok(result.Value);
        }

        [HttpGet("playlists")]
        public async Task<IActionResult> GetPlaylists(CancellationToken ct)
        {
            var result = await _service.GetPlaylistsAsync(ct);

            return Ok(result);
        }

        [HttpGet("playlists/{id:guid}")]
        public async Task<IActionResult> GetPlaylistById(CancellationToken ct, Guid id)
        {
            var result = await _service.GetPlaylistByIdAsync(id, ct);

            if (!result.IsSuccessful)
                return NotFound(result.ErrorMessage);

            return Ok(result.Value);
        }
    }
}

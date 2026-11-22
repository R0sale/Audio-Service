using Application.Contracts;
using Microsoft.AspNetCore;
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
            var track = await _service.GetTrackByIdAsync(id, HttpContext.RequestAborted);

            return Ok(track);
        }

        [HttpGet("playlists")]
        public async Task<IActionResult> GetPlaylists(CancellationToken ct)
        {
            return Ok(await _service.GetPlaylistsAsync(ct));
        }

        [HttpGet("playlists/{id:guid}")]
        public async Task<IActionResult> GetPlaylistById(CancellationToken ct, Guid id)
        {
            return Ok(await _service.GetPlaylistByIdAsync(id, ct));
        }
    }
}

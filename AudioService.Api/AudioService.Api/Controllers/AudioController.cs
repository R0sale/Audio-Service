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
        private readonly IPlaylistsService _playlistsService;
        private readonly ITracksService _tracksService;

        public AudioController(IPlaylistsService playlistsService, ITracksService tracksService)
        {
            _playlistsService = playlistsService;
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

        [HttpGet("playlists")]
        public async Task<IActionResult> GetPlaylists(CancellationToken ct)
        {
            var result = await _playlistsService.GetPlaylistsAsync(ct);

            return Ok(result);
        }

        [HttpGet("playlists/{id:guid}")]
        public async Task<IActionResult> GetPlaylistById(CancellationToken ct, Guid id)
        {
            var result = await _playlistsService.GetPlaylistByIdAsync(id, ct);

            if (!result.IsSuccessful)
                return NotFound(result.ErrorMessage);

            return Ok(result.Value);
        }
    }
}

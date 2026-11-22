using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AudioService.Api.Controllers
{
    [ApiController]
    [Route("api/playlists")]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistsService _playlistsService;

        public PlaylistsController(IPlaylistsService playlistsService)
        {
            _playlistsService = playlistsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlaylists(CancellationToken ct)
        {
            var result = await _playlistsService.GetPlaylistsAsync(ct);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPlaylistById(CancellationToken ct, Guid id)
        {
            var result = await _playlistsService.GetPlaylistByIdAsync(id, ct);

            if (!result.IsSuccessful)
                return NotFound(result.ErrorMessage);

            return Ok(result.Value);
        }
    }
}

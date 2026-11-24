using Application.DTOs;
using Domain.Shared;

namespace Application.Contracts
{
    public interface IPlaylistsService
    {
        Task<IEnumerable<PlaylistDto>> GetPlaylistsAsync(CancellationToken ct);
        Task<Result<PlaylistDto>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct);
    }
}

using Application.DTOs;
using Domain.Shared;

namespace Application.Contracts
{
    public interface IPlaylistsService
    {
        Task<IEnumerable<PlaylistDto>> GetPlaylistsAsync(CancellationToken ct);
        Task<IEnumerable<PlaylistDto>> GetFeaturedPlaylistsAsync(int numberOfPlaylists, CancellationToken ct);
        Task<Result<PlaylistDto>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct);
    }
}

using Domain.Models;

namespace Application.Contracts
{
    public interface IPlaylistsRepository
    {
        Task<IEnumerable<Playlist>> GetPlaylistsAsync(CancellationToken ct);
        Task<Playlist?> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct);
    }
}

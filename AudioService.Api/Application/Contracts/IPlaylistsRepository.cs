using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface IPlaylistsRepository
    {
        Task<IEnumerable<Playlist>> GetPlaylistsAsync(CancellationToken ct);
        Task<Playlist?> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct);
    }
}

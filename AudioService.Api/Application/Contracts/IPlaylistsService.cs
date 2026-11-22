using Domain.Models;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface IPlaylistsService
    {
        Task<IEnumerable<Playlist>> GetPlaylistsAsync(CancellationToken ct);
        Task<Result<Playlist>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct);
    }
}

using Application.DTOs;
using Domain.Models;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface IPlaylistsService
    {
        Task<IEnumerable<PlaylistDto>> GetPlaylistsAsync(CancellationToken ct);
        Task<Result<PlaylistDto>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct);
    }
}

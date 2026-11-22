using Application.Contracts;
using Domain.Models;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class PlaylistsService : IPlaylistsService
    {
        private readonly IPlaylistsRepository _repository;

        public PlaylistsService(IPlaylistsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsAsync(CancellationToken ct)
        {
            var result = await _repository.GetPlaylistsAsync(ct);

            return result;
        }

        public async Task<Result<Playlist>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct)
        {
            var result = await _repository.GetPlaylistByIdAsync(playlistId, ct);

            if (result == null)
                return Result<Playlist>.Failure($"Couldn't find playlist with playlistId {playlistId}");

            return Result<Playlist>.Success(result);
        }
    }
}

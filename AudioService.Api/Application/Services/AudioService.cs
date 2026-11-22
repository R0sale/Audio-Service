using Application.Contracts;
using Domain.Models;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class AudioService : IAudioService
    {
        private readonly IAudioRepository _repository;

        public AudioService(IAudioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Track>> GetTrackByIdAsync(Guid trackId, CancellationToken ct)
        {
            var result = await _repository.GetTrackByIdAsync(trackId, ct);

            if (result == null)
                return Result<Track>.Failure($"Couldn't find track with trackId {trackId}");

            return Result<Track>.Success(result);
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

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

            return result;
        }

        public async Task<Result<IEnumerable<Playlist>>> GetPlaylistsAsync(CancellationToken ct)
        {
            var result = await _repository.GetPlaylistsAsync(ct);

            return result;
        }

        public async Task<Result<Playlist>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct)
        {
            var result = await _repository.GetPlaylistByIdAsync(playlistId, ct);

            return result;
        }
    }
}

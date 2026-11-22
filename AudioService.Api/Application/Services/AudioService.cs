using Application.Contracts;
using Domain.Models;
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

        public async Task<Track> GetTrackByIdAsync(Guid trackId, CancellationToken ct)
        {
            var track = await _repository.GetTrackByIdAsync(trackId, ct);

            return track;
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsAsync(CancellationToken ct)
        {
            var playlists = await _repository.GetPlaylistsAsync(ct);

            return playlists;
        }

        public async Task<Playlist> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct)
        {
            var playlist = await _repository.GetPlaylistByIdAsync(playlistId, ct);

            return playlist;
        }
    }
}

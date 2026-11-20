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

        public async Task<Track> GetTrackByIdAsync(string trackId, CancellationToken ct)
        {
            var track = await _repository.GetTrackByIdAsync(trackId, ct);

            return track;
        }
    }
}

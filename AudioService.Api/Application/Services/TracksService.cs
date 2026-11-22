using Application.Contracts;
using Domain.Models;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class TracksService : ITracksService
    {
        private readonly ITracksRepository _repository;

        public TracksService(ITracksRepository repository)
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
    }
}

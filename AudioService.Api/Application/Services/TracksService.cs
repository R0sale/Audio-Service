using Application.Contracts;
using Application.DTOs;
using Domain.Errors;
using Domain.Models;
using Domain.Shared;
using Domain.Enums;
using System.Net;
using Application.Mappers;

namespace Application.Services
{
    public class TracksService : ITracksService
    {
        private readonly ITracksRepository _repository;
        private readonly IMediaStorage _storage;

        public TracksService(ITracksRepository repository, IMediaStorage storage)
        {
            _repository = repository;
            _storage = storage;
        }

        public async Task<Result<TrackDto>> GetTrackByIdAsync(Guid trackId, CancellationToken ct)
        {
            var track = await _repository.GetTrackByIdAsync(trackId, ct);

            if (track == null)
                return Result<TrackDto>.Failure(new ObjectNotFoundError($"Couldn't find track with trackId {trackId}", HttpStatusCode.NotFound));

            var result = track.ToTrackDto(_storage);

            return Result<TrackDto>.Success(result);
        }

        public async Task<IEnumerable<TrackDto>> GetPopularTracksAsync(int numberofTracks, CancellationToken ct)
        {
            var tracks = await _repository.GetPopularTracksAsync(numberofTracks, ct);

            return tracks.ToTracksDto(_storage);
        }
    }
}

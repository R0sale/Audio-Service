using Application.Contracts;
using Application.DTOs;
using Domain.Errors;
using Domain.Models;
using Domain.Shared;
using Domain.Enums;
using System.Net;

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

            var audioUrl = _storage.GetFullUrl(MediaKind.Audio, track.AudioBlobName);

            var result = MapToTrackDto(track, audioUrl);

            return Result<TrackDto>.Success(result);
        }

        public async Task<IEnumerable<TrackDto>> GetPopularTracksAsync(int numberofTracks, CancellationToken ct)
        {
            var tracks = await _repository.GetPopularTracksAsync(numberofTracks, ct);

            var result = new List<TrackDto>();
            foreach (var track in tracks)
            {
                var audioUrl = _storage.GetFullUrl(MediaKind.Audio, track.AudioBlobName);
                result.Add(MapToTrackDto(track, audioUrl));
            }

            return result;
        }

        private TrackDto MapToTrackDto(Track track, string audioUrl)
        {
            return new TrackDto
            {
                Id = track.Id,
                Album = track.Album,
                Artist = track.Artist,
                AudioUrl = audioUrl,
                CoverUrl = track.CoverBlobName,
                DurationInSeconds = track.DurationInSeconds,
                Title = track.Title
            };
        }
    }
}

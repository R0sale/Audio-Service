using Application.Contracts;
using Application.DTOs;
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

        public async Task<Result<TrackDto>> GetTrackByIdAsync(Guid trackId, CancellationToken ct)
        {
            var track = await _repository.GetTrackByIdAsync(trackId, ct);

            if (track == null)
                return Result<TrackDto>.Failure($"Couldn't find track with trackId {trackId}");

            var result = new TrackDto
            {
                Id = track.Id,
                Album = track.Album,
                Artist = track.Artist,
                AudioBlobName = track.AudioBlobName,
                CoverBlobName = track.CoverBlobName,
                DurationInSeconds = track.DurationInSeconds,
                Title = track.Title
            };

            return Result<TrackDto>.Success(result);
        }
    }
}

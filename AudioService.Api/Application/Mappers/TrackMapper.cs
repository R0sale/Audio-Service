using Application.Contracts;
using Application.DTOs;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappers
{
    public static class TrackMapper
    {
        public static TrackDto ToTrackDto(this Track track, IMediaStorage storage)
        {
            var audioUrl = storage.GetFullUrl(MediaKind.Audio, track.AudioBlobName);
            var coverUrl = track.CoverBlobName == null ? null : storage.GetFullUrl(MediaKind.Cover, track.CoverBlobName);

            return new TrackDto
            {
                Id = track.Id,
                Album = track.Album,
                Artist = track.Artist,
                AudioUrl = audioUrl,
                CoverUrl = coverUrl,
                DurationInSeconds = track.DurationInSeconds,
                Title = track.Title
            };
        }

        public static IEnumerable<TrackDto> ToTracksDto(this IEnumerable<Track> tracks, IMediaStorage storage)
        {
            var result = new List<TrackDto>();
            foreach (var track in tracks)
            {
                result.Add(track.ToTrackDto(storage));
            }

            return result;
        }
    }
}

using Application.Contracts;
using Application.DTOs;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappers
{
    public static class PlaylistMapper
    {
        public static PlaylistDto ToPlaylistDto(this Playlist playlist, IMediaStorage storage)
        {
            var tracks = new List<PlaylistTrackDto>();
            foreach (var track in playlist.Tracks)
            {
                tracks.Add(new PlaylistTrackDto
                {
                    Order = track.Order,
                    Track = TrackMapper.MapToTrackDto(track.Track, storage)
                });
            }

            var playlistCoverUrl = playlist.CoverBlobName == null ? null : storage.GetFullUrl(MediaKind.Cover, playlist.CoverBlobName);

            return new PlaylistDto
            {
                CoverUrl = playlistCoverUrl,
                Description = playlist.Description,
                Id = playlist.Id,
                Title = playlist.Title,
                Tracks = tracks
            };
        }

        public static IEnumerable<PlaylistDto> ToPlaylistsDto(this IEnumerable<Playlist> playlists, IMediaStorage storage)
        {
            var result = new List<PlaylistDto>();
            foreach (var playlist in playlists)
            {
                result.Add(playlist.MapToPlaylistDto(storage));
            }

            return result;
        }
    }
}

using Application.Contracts;
using Application.DTOs;
using Domain.Errors;
using Domain.Models;
using Domain.Shared;
using Domain.Enums;
using System.Net;

namespace Application.Services
{
    public class PlaylistsService : IPlaylistsService
    {
        private readonly IPlaylistsRepository _repository;
        private readonly IMediaStorage _storage;

        public PlaylistsService(IPlaylistsRepository repository, IMediaStorage storage)
        {
            _repository = repository;
            _storage = storage;
        }

        public async Task<IEnumerable<PlaylistDto>> GetPlaylistsAsync(CancellationToken ct)
        {
            var playlists = await _repository.GetPlaylistsAsync(ct);

            var result = new List<PlaylistDto>();
            foreach (var playlist in playlists)
            {
                result.Add(MapToPlaylistDto(playlist));
            }

            return result;
        }

        public async Task<Result<PlaylistDto>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct)
        {
            var playlist = await _repository.GetPlaylistByIdAsync(playlistId, ct);

            if (playlist == null)
                return Result<PlaylistDto>.Failure(new ObjectNotFoundError($"Couldn't find playlist with playlistId {playlistId}", HttpStatusCode.NotFound));

            var result = MapToPlaylistDto(playlist);

            return Result<PlaylistDto>.Success(result);
        }

        private PlaylistDto MapToPlaylistDto(Playlist playlist)
        {
            var tracks = new List<PlaylistTrackDto>();
            foreach (var track in playlist.Tracks)
            {
                var audioUrl = _storage.GetFullUrl(MediaKind.Audio, track.Track.AudioBlobName);

                tracks.Add(new PlaylistTrackDto
                {
                    Order = track.Order,
                    Track = new TrackDto
                    {
                        Id = track.Track.Id,
                        Album = track.Track.Album,
                        Artist = track.Track.Artist,
                        AudioUrl = track.Track.AudioBlobName,
                        CoverUrl = track.Track.CoverBlobName,
                        DurationInSeconds = track.Track.DurationInSeconds,
                        Title = track.Track.Title
                    }
                });
            }

            return new PlaylistDto
            {
                CoverBlobName = playlist.CoverBlobName,
                Description = playlist.Description,
                Id = playlist.Id,
                Title = playlist.Title,
                Tracks = tracks
            };
        }
    }
}

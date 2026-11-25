using Application.Contracts;
using Application.DTOs;
using Application.Mappers;
using Domain.Enums;
using Domain.Errors;
using Domain.Models;
using Domain.Shared;
using System.Diagnostics;
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

            return playlists.ToPlaylistsDto(_storage);
        }

        public async Task<Result<PlaylistDto>> GetPlaylistByIdAsync(Guid playlistId, CancellationToken ct)
        {
            var playlist = await _repository.GetPlaylistByIdAsync(playlistId, ct);

            if (playlist == null)
                return Result<PlaylistDto>.Failure(new ObjectNotFoundError($"Couldn't find playlist with playlistId {playlistId}", HttpStatusCode.NotFound));

            var result = playlist.ToPlaylistDto(_storage);

            return Result<PlaylistDto>.Success(result);
        }
    }
}

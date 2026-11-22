using Application.DTOs;
using Domain.Models;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface ITracksService
    {
        Task<Result<TrackDto>> GetTrackByIdAsync(Guid trackId, CancellationToken ct);
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface IAudioService
    {
        Task<Track> GetTrackByIdAsync(Guid trackId, CancellationToken ct);
    }
}

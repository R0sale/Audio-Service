using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public sealed class PlaylistTrack
    {
        public Guid PlaylistId { get; set; }
        public Guid TrackId { get; set; }
        public Playlist Playlist { get; set; }
        public Track Track { get; set; }
        public int Order { get; set; }
    }
}

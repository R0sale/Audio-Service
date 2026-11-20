using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public sealed class Playlist
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverBlobName { get; set; }
        public string[] TrackIds { get; set; }
    }
}

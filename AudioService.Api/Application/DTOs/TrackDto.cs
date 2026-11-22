using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public sealed class TrackDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string? Album { get; set; }
        public int DurationInSeconds { get; set; }
        public string AudioBlobName { get; set; }
        public string CoverBlobName { get; set; }
    }
}

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
        public string AudioUrl { get; set; }
        public string? CoverUrl { get; set; }
    }
}

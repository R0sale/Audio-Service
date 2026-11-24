using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Domain.Models
{
    public sealed class Track
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string? Album { get; set; }
        public int DurationInSeconds { get; set; }
        public string AudioBlobName { get; set; }
        public string? CoverBlobName { get; set; }
    }
}

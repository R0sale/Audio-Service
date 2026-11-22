using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverBlobName { get; set; }

        public List<PlaylistTrackDto> Tracks { get; set; } = [];
    }

    public class PlaylistTrackDto
    {
        public TrackDto Track { get; set; }
        public int Order { get; set; }
    }
}

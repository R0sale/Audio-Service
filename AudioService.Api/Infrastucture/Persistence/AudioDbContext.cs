using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Persistence
{
    public class AudioDbContext : DbContext
    {
        public AudioDbContext(DbContextOptions<AudioDbContext> options) : base(options)
        {
        }

        public DbSet<Track> Tracks { get; set; }   
        public DbSet<Playlist> Playlists { get; set; }
    }
}

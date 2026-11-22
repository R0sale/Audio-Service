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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PlaylistTrack>()
                .HasKey(pt => new { pt.PlaylistId, pt.TrackId });

            builder.Entity<PlaylistTrack>()
                .HasOne(pt => pt.Playlist)
                .WithMany(pt => pt.Tracks)
                .HasForeignKey(pt => pt.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PlaylistTrack>()
                .HasOne(pt => pt.Track)
                .WithMany()
                .HasForeignKey(pt => pt.TrackId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PlaylistTrack>()
                .HasIndex(x => new { x.PlaylistId, x.Order })
                .IsUnique();
        }
    }
}

import { PlayPlaylistButton } from '@/features/play-playlist'
import { mockPlaylists, PlaylistCard } from '@/entities/playlist'

export function FeaturedPlaylists() {
  return (
    <section aria-labelledby="featured-heading">
      <h2 id="featured-heading" className="mb-4 text-xl font-bold text-white">
        Featured playlists
      </h2>
      <div className="grid grid-cols-2 gap-4 sm:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5">
        {mockPlaylists.map((playlist) => (
          <PlaylistCard key={playlist.id} playlist={playlist} action={<PlayPlaylistButton playlist={playlist} />} />
        ))}
      </div>
    </section>
  )
}

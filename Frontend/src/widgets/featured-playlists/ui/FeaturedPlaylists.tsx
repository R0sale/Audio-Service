import { PlaylistCard } from '@/entities/playlist'
import type { Playlist } from '@/entities/playlist'
import { PlayPlaylistButton } from '@/features/play-playlist'

interface FeaturedPlaylistsProps {
  playlists: Playlist[]
}

export function FeaturedPlaylists({ playlists }: FeaturedPlaylistsProps) {
  return (
    <section aria-labelledby="featured-heading">
      <h2 id="featured-heading" className="mb-4 text-xl font-bold text-white">
        Featured playlists
      </h2>
      <div className="grid grid-cols-2 gap-4 sm:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5">
        {playlists.map((playlist) => (
          <PlaylistCard key={playlist.id} playlist={playlist} action={<PlayPlaylistButton playlist={playlist} />} />
        ))}
      </div>
    </section>
  )
}

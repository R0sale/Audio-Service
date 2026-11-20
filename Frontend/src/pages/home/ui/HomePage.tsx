import { FeaturedPlaylists } from '@/widgets/featured-playlists'
import { PopularTracks } from '@/widgets/popular-tracks'
import { TopBar } from '@/widgets/top-bar'

export function HomePage() {
  return (
    <div className="space-y-10 bg-linear-to-b from-accent/25 via-surface-raised to-surface-raised p-6 md:rounded-lg">
      <TopBar />
      <FeaturedPlaylists />
      <PopularTracks />
    </div>
  )
}

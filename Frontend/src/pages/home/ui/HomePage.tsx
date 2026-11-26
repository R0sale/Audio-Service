import { FeaturedPlaylists } from '@/widgets/featured-playlists'
import { TopBar } from '@/widgets/top-bar'
import type { homeLoader } from '../api/homeLoader'
import { useLoaderData } from 'react-router'
import { TrackList } from '@/widgets/track-list'

const QUEUE_ID = 'popular-tracks'

export function HomePage() {
  const { popularTracks, featuredPlaylists } = useLoaderData<typeof homeLoader>()
  return (
    <div className="space-y-10 bg-linear-to-b from-accent/25 via-surface-raised to-surface-raised p-6 md:rounded-lg">
      <TopBar />
      <FeaturedPlaylists playlists={featuredPlaylists} />
      <section aria-labelledby="popular-heading">
      <h2 id="popular-heading" className="mb-4 text-xl font-bold text-white">
        Popular tracks
      </h2>
      <TrackList tracks={popularTracks} queueId={QUEUE_ID} />
    </section>
    </div>
  )
}

import { useCurrentTrackId, usePlayerStore } from '@/entities/player'
import { TrackRow, type Track } from '@/entities/track'

const QUEUE_ID = 'popular-tracks'

interface PopularTracksProps {
  tracks: Track[]
}

export function PopularTracks({ tracks }: PopularTracksProps) {
  const currentTrackId = useCurrentTrackId()
  const isPlaying = usePlayerStore((state) => state.isPlaying)
  const playQueue = usePlayerStore((state) => state.playQueue)
  const togglePlay = usePlayerStore((state) => state.togglePlay)

  return (
    <section aria-labelledby="popular-heading">
      <h2 id="popular-heading" className="mb-4 text-xl font-bold text-white">
        Popular tracks
      </h2>
      <ol>
        {tracks.map((track, index) => {
          const isActive = track.id === currentTrackId
          return (
            <TrackRow
              key={track.id}
              track={track}
              position={index + 1}
              isActive={isActive}
              isPlaying={isPlaying}
              onPlay={() => (isActive ? togglePlay() : playQueue(tracks, index, QUEUE_ID))}
            />
          )
        })}
      </ol>
    </section>
  )
}

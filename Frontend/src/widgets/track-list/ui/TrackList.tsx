import { useCurrentTrackId, usePlayerStore } from '@/entities/player'
import { TrackRow, type Track } from '@/entities/track'

interface TrackListProps {
  tracks: Track[]
  queueId: string
}

export function TrackList({ tracks, queueId }: TrackListProps) {
  const currentTrackId = useCurrentTrackId()
  const isPlaying = usePlayerStore((state) => state.isPlaying)
  const playQueue = usePlayerStore((state) => state.playQueue)
  const togglePlay = usePlayerStore((state) => state.togglePlay)

  return (
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
              onPlay={() => (isActive ? togglePlay() : playQueue(tracks, index, queueId))}
            />
          )
        })}
      </ol>
  )
}

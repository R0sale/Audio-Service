import { PlaybackControls } from '@/features/playback-controls'
import { SeekBar } from '@/features/seek-track'
import { VolumeControl } from '@/features/volume-control'
import { useCurrentTrack } from '@/entities/player'
import { TrackCover } from '@/entities/track'

type PlayerBarProps = {
  className?: string
}

export function PlayerBar({ className = '' }: PlayerBarProps) {
  const track = useCurrentTrack()

  return (
    <footer
      aria-label="Player"
      className={`grid grid-cols-[1fr_auto] items-center gap-4 border-t border-zinc-800 bg-black px-4 py-3 md:grid-cols-[1fr_minmax(0,2fr)_1fr] ${className}`}
    >
      <div className="flex min-w-0 items-center gap-3">
        {track ? (
          <>
            <TrackCover track={track} className="size-14" />
            <div className="min-w-0">
              <p className="truncate font-medium text-white">{track.title}</p>
              <p className="truncate text-sm text-muted">{track.artist}</p>
            </div>
          </>
        ) : (
          <p className="text-sm text-muted">Pick a track to start listening</p>
        )}
      </div>

      <div className="flex flex-col items-center gap-1">
        <PlaybackControls />
        <SeekBar />
      </div>

      <div className="hidden justify-end md:flex">
        <VolumeControl />
      </div>
    </footer>
  )
}

import { AudioLines, Pause, Play } from 'lucide-react'
import { formatTime } from '@/shared/lib'
import type { Track } from '../model/types'
import { TrackCover } from './TrackCover'

type TrackRowProps = {
  track: Track
  position: number
  isActive: boolean
  isPlaying: boolean
  onPlay: () => void
}

export function TrackRow({ track, position, isActive, isPlaying, onPlay }: TrackRowProps) {
  const showPause = isActive && isPlaying

  return (
    <li>
      <button
        type="button"
        onClick={onPlay}
        aria-label={showPause ? `Pause ${track.title}` : `Play ${track.title}`}
        className="group grid w-full cursor-pointer grid-cols-[2rem_1fr_auto] items-center gap-4 rounded-md px-3 py-2 text-left transition hover:bg-surface-hover focus-visible:outline-2 focus-visible:outline-accent sm:grid-cols-[2rem_1fr_1fr_auto]"
      >
        <span className="flex justify-center text-sm text-muted tabular-nums">
          <span className="group-hover:hidden">
            {showPause ? (
              <AudioLines className="size-4 text-accent" />
            ) : (
              <span className={isActive ? 'text-accent' : ''}>{position}</span>
            )}
          </span>
          <span className="hidden text-white group-hover:inline">
            {showPause ? <Pause className="size-4" fill="currentColor" /> : <Play className="size-4" fill="currentColor" />}
          </span>
        </span>

        <span className="flex min-w-0 items-center gap-3">
          <TrackCover track={track} />
          <span className="min-w-0">
            <span className={`block truncate font-medium ${isActive ? 'text-accent' : 'text-white'}`}>{track.title}</span>
            <span className="block truncate text-sm text-muted">{track.artist}</span>
          </span>
        </span>

        <span className="hidden truncate text-sm text-muted sm:block">{track.album}</span>

        <span className="text-sm text-muted tabular-nums">{formatTime(track.durationSec)}</span>
      </button>
    </li>
  )
}

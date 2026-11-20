import type { Track } from '../model/types'

type TrackCoverProps = {
  track: Pick<Track, 'cover' | 'title'>
  className?: string
}

export function TrackCover({ track, className = 'size-10' }: TrackCoverProps) {
  return (
    <div
      role="img"
      aria-label={`${track.title} cover`}
      className={`shrink-0 rounded ${className}`}
      style={{ background: track.cover }}
    />
  )
}

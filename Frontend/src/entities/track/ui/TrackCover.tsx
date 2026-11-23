import type { Track } from '../model/types'

type TrackCoverProps = {
  track: Pick<Track, 'coverUrl' | 'title'>
  className?: string
}

export function TrackCover({ track, className = 'size-10' }: TrackCoverProps) {
  return (
    <div
      role="img"
      aria-label={`${track.title} cover`}
      className={`shrink-0 rounded ${className}`}
      style={{ background: track.coverUrl ? `url(${track.coverUrl}) center/cover no-repeat` : 'linear-gradient(135deg, #4f46e5, #3b82f6)' }}
    />
  )
}

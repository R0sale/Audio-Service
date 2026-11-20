import { Pause, Play, SkipBack, SkipForward } from 'lucide-react'
import { useCurrentTrack, usePlayerStore } from '@/entities/player'
import { IconButton } from '@/shared/ui'

export function PlaybackControls() {
  const hasTrack = useCurrentTrack() !== null
  const isPlaying = usePlayerStore((state) => state.isPlaying)
  const togglePlay = usePlayerStore((state) => state.togglePlay)
  const next = usePlayerStore((state) => state.next)
  const previous = usePlayerStore((state) => state.previous)

  return (
    <div className="flex items-center gap-2">
      <IconButton label="Previous" icon={<SkipBack className="size-5" fill="currentColor" />} onClick={previous} disabled={!hasTrack} />
      <IconButton
        label={isPlaying ? 'Pause' : 'Play'}
        variant="primary"
        icon={isPlaying ? <Pause className="size-5" fill="currentColor" /> : <Play className="size-5 translate-x-px" fill="currentColor" />}
        onClick={togglePlay}
        disabled={!hasTrack}
      />
      <IconButton label="Next" icon={<SkipForward className="size-5" fill="currentColor" />} onClick={next} disabled={!hasTrack} />
    </div>
  )
}

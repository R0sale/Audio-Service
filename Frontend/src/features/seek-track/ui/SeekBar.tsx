import { usePlayerStore } from '@/entities/player'
import { formatTime } from '@/shared/lib'
import { Slider } from '@/shared/ui'

export function SeekBar() {
  const currentTime = usePlayerStore((state) => state.currentTime)
  const duration = usePlayerStore((state) => state.duration)
  const seek = usePlayerStore((state) => state.seek)

  return (
    <div className="flex w-full items-center gap-2 text-xs text-muted tabular-nums">
      <span className="w-10 text-right">{formatTime(currentTime)}</span>
      <Slider
        label="Seek"
        value={Math.min(currentTime, duration)}
        max={duration}
        step={0.1}
        disabled={duration === 0}
        onChange={seek}
        className="flex-1"
      />
      <span className="w-10">{formatTime(duration)}</span>
    </div>
  )
}

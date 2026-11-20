import { Volume1, Volume2, VolumeX } from 'lucide-react'
import { usePlayerStore } from '@/entities/player'
import { IconButton, Slider } from '@/shared/ui'

export function VolumeControl() {
  const volume = usePlayerStore((state) => state.volume)
  const isMuted = usePlayerStore((state) => state.isMuted)
  const setVolume = usePlayerStore((state) => state.setVolume)
  const toggleMute = usePlayerStore((state) => state.toggleMute)

  const effectiveVolume = isMuted ? 0 : volume
  const Icon = effectiveVolume === 0 ? VolumeX : effectiveVolume < 0.5 ? Volume1 : Volume2

  return (
    <div className="flex items-center gap-1">
      <IconButton label={isMuted ? 'Unmute' : 'Mute'} size="sm" icon={<Icon className="size-5" />} onClick={toggleMute} />
      <Slider label="Volume" value={effectiveVolume} max={1} step={0.01} onChange={setVolume} className="w-24" />
    </div>
  )
}

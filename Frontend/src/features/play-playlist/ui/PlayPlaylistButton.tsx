import { Pause, Play } from 'lucide-react'
import { usePlayerStore } from '@/entities/player'
import type { Playlist } from '@/entities/playlist'
import { IconButton } from '@/shared/ui'

type PlayPlaylistButtonProps = {
  playlist: Playlist
}

export function PlayPlaylistButton({ playlist }: PlayPlaylistButtonProps) {
  const isCurrent = usePlayerStore((state) => state.queueId === playlist.id)
  const isPlaying = usePlayerStore((state) => state.isPlaying)
  const playQueue = usePlayerStore((state) => state.playQueue)
  const togglePlay = usePlayerStore((state) => state.togglePlay)

  const showPause = isCurrent && isPlaying

  const handleClick = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault()
    
    if (isCurrent) togglePlay()
    else playQueue(playlist.tracks.toSorted((a, b) => a.order - b.order).map((t) => t.track), 0, playlist.id)
  }

  return (
    <IconButton
      label={showPause ? `Pause ${playlist.title}` : `Play ${playlist.title}`}
      variant="primary"
      size="lg"
      className="bg-accent! text-white! shadow-lg shadow-black/40 ring-1 ring-white/15 hover:bg-accent-hover! hover:shadow-accent/40 active:scale-95"
      icon={showPause ? <Pause className="size-5" fill="currentColor" /> : <Play className="size-5 translate-x-px" fill="currentColor" />}
      onClick={handleClick}
    />
  )
}

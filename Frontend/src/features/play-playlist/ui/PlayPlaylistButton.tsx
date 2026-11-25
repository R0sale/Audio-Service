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

  const handleClick = () => {
    if (isCurrent) togglePlay()
    else playQueue(playlist.tracks.map((t) => t.track), 0, playlist.id)
  }

  return (
    <IconButton
      label={showPause ? `Pause ${playlist.title}` : `Play ${playlist.title}`}
      variant="primary"
      size="lg"
      className="bg-accent text-white shadow-xl hover:bg-accent-hover"
      icon={showPause ? <Pause className="size-5" fill="currentColor" /> : <Play className="size-5 translate-x-px" fill="currentColor" />}
      onClick={handleClick}
    />
  )
}

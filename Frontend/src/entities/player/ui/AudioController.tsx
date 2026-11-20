import { useEffect, useRef } from 'react'
import { useCurrentTrack } from '../model/selectors'
import { usePlayerStore } from '../model/playerStore'

export function AudioController() {
  const audioRef = useRef<HTMLAudioElement>(null)
  const audioUrl = useCurrentTrack()?.audioUrl ?? null
  const isPlaying = usePlayerStore((state) => state.isPlaying)
  const volume = usePlayerStore((state) => state.volume)
  const isMuted = usePlayerStore((state) => state.isMuted)
  const seekRequest = usePlayerStore((state) => state.seekRequest)
  const pause = usePlayerStore((state) => state.pause)
  const clearSeekRequest = usePlayerStore((state) => state.clearSeekRequest)
  const next = usePlayerStore((state) => state.next)
  const setProgress = usePlayerStore((state) => state.setProgress)
  const setDuration = usePlayerStore((state) => state.setDuration)

  useEffect(() => {
    const audio = audioRef.current
    if (!audio) 
      return

    if (audioUrl) {
      audio.src = audioUrl
    } else {
      audio.removeAttribute('src')
    }

    audio.load()
  }, [audioUrl])

  useEffect(() => {
    const audio = audioRef.current
    if (!audio || !audioUrl) 
      return

    if (isPlaying) {
      audio.play().catch((error: unknown) => {
        if (error instanceof DOMException && error.name === 'AbortError') 
          return

        pause()
      })
    } else {
      audio.pause()
    }
  }, [isPlaying, audioUrl])

  useEffect(() => {
    const audio = audioRef.current
    if (!audio) 
      return

    audio.volume = volume
    audio.muted = isMuted
  }, [volume, isMuted])

  useEffect(() => {
    const audio = audioRef.current
    if (!audio || seekRequest === null) 
      return

    audio.currentTime = seekRequest
    clearSeekRequest()
  }, [seekRequest])

  return (
    <audio
      ref={audioRef}
      preload="metadata"
      onTimeUpdate={(event) => setProgress(event.currentTarget.currentTime)}
      onDurationChange={(event) => setDuration(event.currentTarget.duration)}
      onEnded={() => next()}
    />
  )
}

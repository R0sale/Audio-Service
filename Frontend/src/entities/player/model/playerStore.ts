import { create } from 'zustand'
import { persist } from 'zustand/middleware'
import type { Track } from '@/entities/track/@x/player'

const RESTART_THRESHOLD_SEC = 3

interface PlayerState {
  queue: Track[]
  queueId: string | null
  currentIndex: number | null
  isPlaying: boolean
  volume: number
  isMuted: boolean
  currentTime: number
  duration: number
  seekRequest: number | null

  playQueue: (tracks: Track[], startIndex?: number, queueId?: string | null) => void
  togglePlay: () => void
  pause: () => void
  next: () => void
  previous: () => void
  seek: (seconds: number) => void
  clearSeekRequest: () => void
  setVolume: (volume: number) => void
  toggleMute: () => void
  setProgress: (currentTime: number) => void
  setDuration: (duration: number) => void
}

const clamp = (value: number, min: number, max: number) => Math.min(max, Math.max(min, value))

export const usePlayerStore = create<PlayerState>()(
  persist(
    (set, get) => ({
      queue: [],
      queueId: null,
      currentIndex: null,
      isPlaying: false,
      volume: 0.8,
      isMuted: false,
      currentTime: 0,
      duration: 0,
      seekRequest: null,

      playQueue: (tracks, startIndex = 0, queueId = null) => {
        if (tracks.length === 0)
          return

        set({
          queue: tracks,
          queueId,
          currentIndex: clamp(startIndex, 0, tracks.length - 1),
          isPlaying: true,
          currentTime: 0,
          seekRequest: 0,
        })
      },

      togglePlay: () => {
        const { currentIndex, queue, isPlaying } = get()

        if (currentIndex === null) {
          if (queue.length > 0)
            set({ currentIndex: 0, isPlaying: true })

          return
        }

        set({ isPlaying: !isPlaying })
      },

      pause: () => set({ isPlaying: false }),

      next: () => {
        const { currentIndex, queue } = get()
        if (currentIndex === null)
          return

        if (currentIndex < queue.length - 1) {
          set({ currentIndex: currentIndex + 1, currentTime: 0, seekRequest: 0 })
        } else {
          set({ isPlaying: false, currentTime: 0, seekRequest: 0 })
        }
      },

      previous: () => {
        const { currentIndex, currentTime } = get()
        if (currentIndex === null)
          return

        if (currentTime > RESTART_THRESHOLD_SEC || currentIndex === 0) {
          set({ currentTime: 0, seekRequest: 0 })
        } else {
          set({ currentIndex: currentIndex - 1, currentTime: 0, seekRequest: 0 })
        }
      },

      seek: (seconds) => {
        const safe = Math.max(0, seconds)
        set({ currentTime: safe, seekRequest: safe })
      },

      clearSeekRequest: () => set({ seekRequest: null }),

      setVolume: (volume) => {
        const safe = clamp(volume, 0, 1)
        set({ volume: safe, isMuted: safe === 0 })
      },

      toggleMute: () => {
        const { isMuted, volume } = get()

        if (isMuted && volume === 0) 
          set({ isMuted: false, volume: 0.5 })
        else set({ isMuted: !isMuted })
      },

      setProgress: (currentTime) => set({ currentTime }),

      setDuration: (duration) => set({ duration: Number.isFinite(duration) ? duration : 0 }),
    }),
    {
      name: 'audio-service-player',
      partialize: (state) => ({ volume: state.volume, isMuted: state.isMuted }),
    },
  ),
)

import { usePlayerStore } from './playerStore'

export const useCurrentTrack = () =>
  usePlayerStore((state) => (state.currentIndex === null ? null : (state.queue[state.currentIndex] ?? null)))

export const useCurrentTrackId = () =>
  usePlayerStore((state) => (state.currentIndex === null ? null : (state.queue[state.currentIndex]?.id ?? null)))

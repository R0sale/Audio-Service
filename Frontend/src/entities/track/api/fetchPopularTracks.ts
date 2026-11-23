import { trackSchema } from '../model/types'
import { z } from 'zod'

export async function fetchPopularTracks(take: number, signal: AbortSignal) {
  const response = await fetch(import.meta.env.VITE_AUDIO_SERVICE_API_URL + `/tracks?take=${take}`, {
    method: 'GET',
    signal: signal
  })

  if (!response.ok) {
    throw new Error(`Failed to fetch popular tracks: ${response.status} ${response.statusText}`)
  }

  const data = await response.json()

  return z.array(trackSchema).parse(data)
}
import z from "zod"
import { playlistSchema } from "../model/types"

export const fetchFeaturedPlaylists = async (limit: number, signal?: AbortSignal) => {
    const response = await fetch(import.meta.env.VITE_AUDIO_SERVICE_API_URL + `/playlists/featured?take=${limit}`, {
        method: 'GET',
        signal: signal
      })
    
      if (!response.ok) {
        throw new Error(`Failed to fetch featured playlists: ${response.status} ${response.statusText}`)
      }
    
      const data = await response.json()
    
      return z.array(playlistSchema).parse(data)
}
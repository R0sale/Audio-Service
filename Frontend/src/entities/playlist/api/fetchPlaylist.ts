import { playlistSchema } from '../model/types'

export const fetchPlaylist = async (id: string, signal?: AbortSignal) => {
    const response = await fetch(import.meta.env.VITE_AUDIO_SERVICE_API_URL + `/playlists/${id}`, {
        method: 'GET',
        signal: signal
    })

    if (!response.ok) {
        throw new Error(`Failed to fetch playlist: ${response.status} ${response.statusText}`)
    }

    const data = await response.json()

    return playlistSchema.parse(data)
}
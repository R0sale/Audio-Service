import { trackSchema } from '@/entities/track/@x/playlist'
import { z } from 'zod'

const playlistTrackSchema = z.object({
  track: trackSchema,
  order: z.number()
})

export const playlistSchema = z.object({
  id: z.string(),
  title: z.string(),
  description: z.string(),
  coverUrl: z.string().nullable(),
  tracks: z.array(playlistTrackSchema)
})

export type Playlist = z.infer<typeof playlistSchema>
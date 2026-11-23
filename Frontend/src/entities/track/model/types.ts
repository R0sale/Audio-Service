import { z } from 'zod'

export const trackSchema = z.object({
  id: z.string(),
  title: z.string(),
  artist: z.string(),
  album: z.string().nullable(),
  durationInSeconds: z.number(),
  audioUrl: z.string(),
  coverUrl: z.string().nullable(),
})

export type Track = z.infer<typeof trackSchema>
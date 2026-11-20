import type { ReactNode } from 'react'
import type { Playlist } from '../model/types'

type PlaylistCardProps = {
  playlist: Playlist
  action?: ReactNode
}

export function PlaylistCard({ playlist, action }: PlaylistCardProps) {
  return (
    <article className="group rounded-lg bg-surface-raised p-3 transition hover:bg-surface-hover">
      <div className="relative mb-3 aspect-square overflow-hidden rounded-md shadow-lg" style={{ background: playlist.cover }}>
        {action && (
          <div className="absolute right-2 bottom-2 translate-y-2 opacity-0 transition group-focus-within:translate-y-0 group-focus-within:opacity-100 group-hover:translate-y-0 group-hover:opacity-100">
            {action}
          </div>
        )}
      </div>
      <h3 className="truncate font-semibold text-white">{playlist.title}</h3>
      <p className="mt-1 line-clamp-2 text-sm text-muted">{playlist.description}</p>
    </article>
  )
}

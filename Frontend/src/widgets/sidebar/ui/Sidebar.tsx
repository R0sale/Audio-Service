import { AudioLines, House, Library, Search, type LucideIcon } from 'lucide-react'
import { usePlayerStore } from '@/entities/player'
import type { Playlist } from '@/entities/playlist';

type NavItem = { label: string; icon: LucideIcon; active?: boolean }

const navItems: NavItem[] = [
  { label: 'Home', icon: House, active: true },
  { label: 'Search', icon: Search },
  { label: 'Your Library', icon: Library },
]

type SidebarProps = {
  className?: string
  playlists: Playlist[]
}

export function Sidebar({ className = '', playlists }: SidebarProps) {
  const queueId = usePlayerStore((state) => state.queueId)
  const isPlaying = usePlayerStore((state) => state.isPlaying)

  return (
    <aside className={`flex min-h-0 flex-col gap-2 bg-black p-2 ${className}`}>
      <div className="rounded-lg bg-surface-raised p-4">
        <div className="mb-6 flex items-center gap-2 px-2 text-lg font-bold text-white">
          <AudioLines className="size-6 text-accent" />
          Audio Service
        </div>
        <nav aria-label="Main">
          <ul className="space-y-1">
            {navItems.map(({ label, icon: Icon, active }) => (
              <li key={label}>
                <a
                  href="#"
                  aria-current={active ? 'page' : undefined}
                  className={`flex items-center gap-4 rounded-md px-2 py-2 font-semibold transition hover:text-white ${active ? 'text-white' : 'text-muted'}`}
                >
                  <Icon className="size-5" />
                  {label}
                </a>
              </li>
            ))}
          </ul>
        </nav>
      </div>

      <div className="min-h-0 flex-1 overflow-y-auto rounded-lg bg-surface-raised p-4">
        <h2 className="mb-3 px-2 text-sm font-semibold tracking-wide text-muted uppercase">Playlists</h2>
        <ul className="space-y-1">
          {playlists.map((playlist) => {
            const isCurrent = queueId === playlist.id
            return (
              <li key={playlist.id} className="flex items-center gap-3 rounded-md px-2 py-2 transition hover:bg-surface-hover">
                <div className="size-10 shrink-0 rounded" />
                <span className={`min-w-0 flex-1 truncate text-sm font-medium ${isCurrent ? 'text-accent' : 'text-white'}`}>
                  {playlist.title}
                </span>
                {isCurrent && isPlaying && <AudioLines className="size-4 shrink-0 text-accent" aria-label="Now playing" />}
              </li>
            )
          })}
        </ul>
      </div>
    </aside>
  )
}

import { PlayerBar } from '@/widgets/player-bar'
import { Sidebar } from '@/widgets/sidebar'
import { AudioController } from '@/entities/player'
import '@/app/styles/index.css'
import { Outlet } from 'react-router'

export function MainLayout() {
  return (
    <div className="grid h-dvh grid-rows-[minmax(0,1fr)_auto] md:grid-cols-[260px_minmax(0,1fr)]">
      <Sidebar className="hidden md:flex" playlists={[]} />
      <main className="min-h-0 overflow-y-auto md:py-2 md:pr-2">
        <Outlet />
      </main>
      <PlayerBar className="md:col-span-2" />
      <AudioController />
    </div>
  )
}

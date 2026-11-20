import { HomePage } from '@/pages/home'
import { PlayerBar } from '@/widgets/player-bar'
import { Sidebar } from '@/widgets/sidebar'
import { AudioController } from '@/entities/player'
import './styles/index.css'

export function App() {
  return (
    <div className="grid h-dvh grid-rows-[minmax(0,1fr)_auto] md:grid-cols-[260px_minmax(0,1fr)]">
      <Sidebar className="hidden md:flex" />
      <main className="min-h-0 overflow-y-auto md:py-2 md:pr-2">
        <HomePage />
      </main>
      <PlayerBar className="md:col-span-2" />
      <AudioController />
    </div>
  )
}

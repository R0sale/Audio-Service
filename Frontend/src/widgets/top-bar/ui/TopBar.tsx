import { useState } from 'react'
import { Search } from 'lucide-react'

function getGreeting(date: Date): string {
  const hour = date.getHours()
  if (hour < 12) return 'Good morning'
  if (hour < 18) return 'Good afternoon'
  return 'Good evening'
}

export function TopBar() {
  const [greeting] = useState(() => getGreeting(new Date()))

  return (
    <header className="flex flex-col gap-4 sm:flex-row sm:items-center sm:justify-between">
      <h1 className="text-2xl font-bold text-white sm:text-3xl">{greeting}</h1>
      <label className="relative block w-full sm:w-72">
        <span className="sr-only">Search</span>
        <Search className="pointer-events-none absolute top-1/2 left-3 size-4 -translate-y-1/2 text-muted" />
        <input
          type="search"
          placeholder="What do you want to listen to?"
          className="w-full rounded-full bg-surface-hover py-2 pr-4 pl-9 text-sm text-white placeholder:text-muted focus:outline-2 focus:outline-accent"
        />
      </label>
    </header>
  )
}

type SliderProps = {
  value: number
  max: number
  step?: number
  label: string
  disabled?: boolean
  className?: string
  onChange: (value: number) => void
}

export function Slider({ value, max, step = 1, label, disabled = false, className = '', onChange }: SliderProps) {
  const percent = max > 0 ? Math.min(100, Math.max(0, (value / max) * 100)) : 0

  return (
    <div
      className={`group relative flex h-4 items-center rounded-full has-focus-visible:outline-2 has-focus-visible:outline-offset-2 has-focus-visible:outline-accent ${disabled ? 'opacity-40' : ''} ${className}`}
    >
      <div className="h-1 w-full overflow-hidden rounded-full bg-zinc-700">
        <div
          className="h-full rounded-full bg-zinc-200 transition-colors group-hover:bg-accent"
          style={{ width: `${percent}%` }}
        />
      </div>
      <div
        className="pointer-events-none absolute size-3 -translate-x-1/2 rounded-full bg-white opacity-0 shadow transition-opacity group-hover:opacity-100"
        style={{ left: `${percent}%` }}
      />
      <input
        type="range"
        aria-label={label}
        min={0}
        max={max}
        step={step}
        value={value}
        disabled={disabled}
        onChange={(event) => onChange(Number(event.target.value))}
        className="absolute inset-0 h-full w-full cursor-pointer opacity-0 disabled:cursor-not-allowed"
      />
    </div>
  )
}

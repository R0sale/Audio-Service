import type { Track } from '../model/types'

const sample = (n: number) => `https://www.soundhelix.com/examples/mp3/SoundHelix-Song-${n}.mp3`

export const mockTracks: Track[] = [
  { id: 't1', title: 'Neon Avenue', artist: 'Midnight Atlas', album: 'City Lights', durationSec: 372, audioUrl: sample(1), cover: 'linear-gradient(135deg, #7c3aed, #db2777)' },
  { id: 't2', title: 'Quiet Signals', artist: 'Lumen Field', album: 'Low Frequencies', durationSec: 425, audioUrl: sample(2), cover: 'linear-gradient(135deg, #0ea5e9, #6366f1)' },
  { id: 't3', title: 'Glass Horizon', artist: 'Northbound', album: 'Open Roads', durationSec: 344, audioUrl: sample(3), cover: 'linear-gradient(135deg, #14b8a6, #0ea5e9)' },
  { id: 't4', title: 'Paper Planes', artist: 'Sofa Theory', album: 'Weekend Sketches', durationSec: 302, audioUrl: sample(4), cover: 'linear-gradient(135deg, #f59e0b, #ef4444)' },
  { id: 't5', title: 'Afterglow', artist: 'Midnight Atlas', album: 'City Lights', durationSec: 353, audioUrl: sample(5), cover: 'linear-gradient(135deg, #7c3aed, #db2777)' },
  { id: 't6', title: 'Soft Static', artist: 'Lumen Field', album: 'Low Frequencies', durationSec: 325, audioUrl: sample(6), cover: 'linear-gradient(135deg, #0ea5e9, #6366f1)' },
  { id: 't7', title: 'Tidal Memory', artist: 'Coastline', album: 'Salt & Echo', durationSec: 437, audioUrl: sample(7), cover: 'linear-gradient(135deg, #22c55e, #0d9488)' },
  { id: 't8', title: 'Slow Orbit', artist: 'Northbound', album: 'Open Roads', durationSec: 325, audioUrl: sample(8), cover: 'linear-gradient(135deg, #14b8a6, #0ea5e9)' },
  { id: 't9', title: 'First Light', artist: 'Sofa Theory', album: 'Weekend Sketches', durationSec: 313, audioUrl: sample(9), cover: 'linear-gradient(135deg, #f59e0b, #ef4444)' },
  { id: 't10', title: 'Undertow', artist: 'Coastline', album: 'Salt & Echo', durationSec: 359, audioUrl: sample(10), cover: 'linear-gradient(135deg, #22c55e, #0d9488)' },
]

export function getTracksByIds(ids: readonly string[]): Track[] {
  return ids
    .map((id) => mockTracks.find((track) => track.id === id))
    .filter((track): track is Track => track !== undefined)
}

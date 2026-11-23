import type { Track } from '../model/types'

const sample = (n: number) => `https://www.soundhelix.com/examples/mp3/SoundHelix-Song-${n}.mp3`

export const mockTracks: Track[] = [
  { id: 't1', title: 'Neon Avenue', artist: 'Midnight Atlas', album: 'City Lights', durationInSeconds: 372, audioUrl: sample(1), coverUrl: null },
  { id: 't2', title: 'Quiet Signals', artist: 'Lumen Field', album: 'Low Frequencies', durationInSeconds: 425, audioUrl: sample(2), coverUrl: null },
  { id: 't3', title: 'Glass Horizon', artist: 'Northbound', album: 'Open Roads', durationInSeconds: 344, audioUrl: sample(3), coverUrl: null },
  { id: 't4', title: 'Paper Planes', artist: 'Sofa Theory', album: 'Weekend Sketches', durationInSeconds: 302, audioUrl: sample(4), coverUrl: null },
  { id: 't5', title: 'Afterglow', artist: 'Midnight Atlas', album: 'City Lights', durationInSeconds: 353, audioUrl: sample(5), coverUrl: null },
  { id: 't6', title: 'Soft Static', artist: 'Lumen Field', album: 'Low Frequencies', durationInSeconds: 325, audioUrl: sample(6), coverUrl: null },
  { id: 't7', title: 'Tidal Memory', artist: 'Coastline', album: 'Salt & Echo', durationInSeconds: 437, audioUrl: sample(7), coverUrl: null },
  { id: 't8', title: 'Slow Orbit', artist: 'Northbound', album: 'Open Roads', durationInSeconds: 325, audioUrl: sample(8), coverUrl: null },
  { id: 't9', title: 'First Light', artist: 'Sofa Theory', album: 'Weekend Sketches', durationInSeconds: 313, audioUrl: sample(9), coverUrl: null },
  { id: 't10', title: 'Undertow', artist: 'Coastline', album: 'Salt & Echo', durationInSeconds: 359, audioUrl: sample(10), coverUrl: null },
]

export function getTracksByIds(ids: readonly string[]): Track[] {
  return ids
    .map((id) => mockTracks.find((track) => track.id === id))
    .filter((track): track is Track => track !== undefined)
}

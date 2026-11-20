import type { Playlist } from '../model/types'

export const mockPlaylists: Playlist[] = [
  {
    id: 'p1',
    title: 'Late Night Drive',
    description: 'Synths and city lights for the empty highway.',
    cover: 'linear-gradient(135deg, #4c1d95, #be185d)',
    trackIds: ['t1', 't3', 't5', 't7'],
  },
  {
    id: 'p2',
    title: 'Focus Flow',
    description: 'Steady, wordless tracks to keep you in the zone.',
    cover: 'linear-gradient(135deg, #1e3a8a, #0891b2)',
    trackIds: ['t2', 't4', 't6', 't8'],
  },
  {
    id: 'p3',
    title: 'Morning Energy',
    description: 'Bright tunes to start the day right.',
    cover: 'linear-gradient(135deg, #b45309, #dc2626)',
    trackIds: ['t9', 't10', 't1', 't2'],
  },
  {
    id: 'p4',
    title: 'Chill Electronic',
    description: 'Laid-back beats and soft textures.',
    cover: 'linear-gradient(135deg, #047857, #0e7490)',
    trackIds: ['t3', 't6', 't9'],
  },
  {
    id: 'p5',
    title: 'Deep Work',
    description: 'Long, calm pieces for long, hard problems.',
    cover: 'linear-gradient(135deg, #3f3f46, #6d28d9)',
    trackIds: ['t4', 't5', 't8', 't10'],
  },
]

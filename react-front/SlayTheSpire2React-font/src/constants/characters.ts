export const CHARACTER_OPTIONS = [
  'Ironclad',
  'Silent',
  'Defect',
  'Watcher',
  'The Regent',
] as const

export type Character = (typeof CHARACTER_OPTIONS)[number]

export const ALL_CHARACTERS_VALUE = 'All'

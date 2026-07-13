import { ALL_CHARACTERS_VALUE, CHARACTER_OPTIONS } from '../constants/characters'

export function isAllCharacters(raw: string | undefined | null): boolean {
  if (!raw || raw.trim() === '') {
    return true
  }

  return raw.trim().toLowerCase() === ALL_CHARACTERS_VALUE.toLowerCase()
}

export function parseRelicCharacters(raw: string | undefined | null): string[] {
  if (isAllCharacters(raw)) {
    return [...CHARACTER_OPTIONS]
  }

  return (raw ?? '')
    .split(',')
    .map((item) => item.trim())
    .filter(Boolean)
}

export function formatRelicCharacters(chars: string[]): string {
  const unique = [...new Set(chars.map((item) => item.trim()).filter(Boolean))]

  if (unique.length === 0 || unique.length === CHARACTER_OPTIONS.length) {
    return ALL_CHARACTERS_VALUE
  }

  return unique.join(',')
}

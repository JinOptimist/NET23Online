import { ALL_CHARACTERS_VALUE } from '../constants/characters'
import type { CreateRelicPayload, Relic } from '../types/relic'

const API_BASE = 'https://localhost:7050'

type RelicApiResponse = Partial<Relic> & {
  id?: number
  name?: string
  urlImage?: string
  rarity?: string
  description?: string
  characters?: string
}

function normalizeRelic(raw: RelicApiResponse): Relic {
  return {
    id: raw.id ?? 0,
    name: raw.name ?? '',
    urlImage: raw.urlImage ?? '',
    rarity: raw.rarity ?? '',
    description: raw.description ?? '',
    characters: raw.characters?.trim() || ALL_CHARACTERS_VALUE,
  }
}

export async function getRelics(): Promise<Relic[]> {
  const response = await fetch(`${API_BASE}/GetRelics`)

  if (!response.ok) {
    throw new Error(`Ошибка запроса: ${response.status}`)
  }

  const data = (await response.json()) as RelicApiResponse[]
  return data.map(normalizeRelic)
}

export async function createRelic(payload: CreateRelicPayload): Promise<Relic> {
  const response = await fetch(`${API_BASE}/CreatRelic`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      id: 0,
      ...payload,
    }),
  })

  if (!response.ok) {
    throw new Error(`Ошибка запроса: ${response.status}`)
  }

  const data = (await response.json()) as RelicApiResponse
  return normalizeRelic(data)
}

export async function deleteRelic(id: number): Promise<void> {
  const response = await fetch(`${API_BASE}/DeleteRelic`, {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(id),
  })

  if (!response.ok) {
    throw new Error(`Ошибка запроса: ${response.status}`)
  }
}

export interface Relic {
  id: number
  name: string
  urlImage: string
  rarity: string
  description: string
  characters: string
}

export interface CreateRelicPayload {
  name: string
  urlImage: string
  rarity: string
  description: string
  characters: string
}

export function getRarityClass(rarity: string): string {
  const normalized = rarity.trim().toLowerCase()

  if (normalized.includes('starter')) return 'relic-card--starter'
  if (normalized.includes('common')) return 'relic-card--common'
  if (normalized.includes('uncommon')) return 'relic-card--uncommon'
  if (normalized.includes('rare')) return 'relic-card--rare'
  if (normalized.includes('boss')) return 'relic-card--boss'
  if (normalized.includes('shop')) return 'relic-card--shop'

  return 'relic-card--default'
}

export function getRarityDetailClass(rarity: string): string {
  return getRarityClass(rarity).replace('relic-card--', 'relic-detail--')
}

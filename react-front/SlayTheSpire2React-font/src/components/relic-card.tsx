import { Link } from 'react-router-dom'
import type { Relic } from '../types/relic'
import { getRarityClass } from '../utils/relic-rarity'

interface RelicCardProps {
  relic: Relic
  onDelete?: (id: number) => void
  deleting?: boolean
  linkable?: boolean
}

export const RelicCard = function ({
  relic,
  onDelete,
  deleting,
  linkable = true,
}: RelicCardProps) {
  const rarity = relic.rarity.trim()
  const canLink = linkable && relic.id > 0

  const mainContent = (
    <>
      <div className="relic-card__frame">
        <div className="relic-card__glow" aria-hidden="true" />
        <div className="relic-card__poster">
          {relic.urlImage ? (
            <img src={relic.urlImage} alt={relic.name} loading="lazy" />
          ) : (
            <div className="relic-card__no-image">?</div>
          )}
        </div>
      </div>
      <div className="relic-card__info">
        <span className="relic-card__badge">{rarity}</span>
        <h3 className="relic-card__title">{relic.name}</h3>
        {relic.description.trim() && (
          <p className="relic-card__description">{relic.description}</p>
        )}
      </div>
    </>
  )

  return (
    <article className={`relic-card ${getRarityClass(rarity)} ${canLink ? 'relic-card--linkable' : ''}`}>
      {canLink ? (
        <Link className="relic-card__link" to={`/relics/${relic.id}`}>
          {mainContent}
        </Link>
      ) : (
        <div className="relic-card__static">{mainContent}</div>
      )}
      {onDelete && (
        <button
          type="button"
          className="relic-card__delete"
          onClick={() => onDelete(relic.id)}
          disabled={deleting}
        >
          {deleting ? 'Удаление...' : 'Удалить'}
        </button>
      )}
    </article>
  )
}

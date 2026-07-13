import { useCallback, useEffect, useState } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import '../components/relic-detail.css'
import '../components/relic-list.css'
import { deleteRelic, getRelics } from '../services/relic-service'
import type { Relic } from '../types/relic'
import { isAllCharacters, parseRelicCharacters } from '../utils/relic-characters'
import { getRarityDetailClass } from '../utils/relic-rarity'

export const RelicDetailPage = function () {
  const { id } = useParams()
  const navigate = useNavigate()
  const relicId = Number(id)
  const isValidId = Number.isFinite(relicId)

  const [relic, setRelic] = useState<Relic | null>(null)
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState<string | null>(null)
  const [notFound, setNotFound] = useState(false)
  const [deleting, setDeleting] = useState(false)

  useEffect(() => {
    if (!isValidId) {
      return
    }

    let cancelled = false

    const loadRelic = async () => {
      try {
        const relics = await getRelics()
        const found = relics.find((item) => item.id === relicId)

        if (!cancelled) {
          if (found) {
            setRelic(found)
          } else {
            setNotFound(true)
          }
        }
      } catch (err) {
        if (!cancelled) {
          setError(err instanceof Error ? err.message : 'Не удалось загрузить реликвию')
        }
      } finally {
        if (!cancelled) {
          setLoading(false)
        }
      }
    }

    loadRelic()

    return () => {
      cancelled = true
    }
  }, [isValidId, relicId])

  const handleDelete = useCallback(async () => {
    if (!relic) {
      return
    }

    setDeleting(true)
    setError(null)

    try {
      await deleteRelic(relic.id)
      navigate('/')
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Не удалось удалить реликвию')
      setDeleting(false)
    }
  }, [navigate, relic])

  if (!isValidId) {
    return (
      <section className="relic-detail">
        <Link className="relic-detail__back" to="/">
          ← Назад к коллекции
        </Link>
        <p className="relic-list__status">Реликвия не найдена</p>
      </section>
    )
  }

  if (loading) {
    return <p className="relic-list__status">Загрузка реликвии...</p>
  }

  if (error && !relic) {
    return <p className="relic-list__status relic-list__status--error">{error}</p>
  }

  if (notFound || !relic) {
    return (
      <section className="relic-detail">
        <Link className="relic-detail__back" to="/">
          ← Назад к коллекции
        </Link>
        <p className="relic-list__status">Реликвия не найдена</p>
      </section>
    )
  }

  const rarity = relic.rarity.trim()
  const characterLabels = isAllCharacters(relic.characters)
    ? ['Все персонажи']
    : parseRelicCharacters(relic.characters)

  return (
    <section className={`relic-detail ${getRarityDetailClass(rarity)}`}>
      <Link className="relic-detail__back" to="/">
        ← Назад к коллекции
      </Link>

      <div className="relic-detail__hero">
        <div className="relic-detail__frame">
          <div className="relic-detail__glow" aria-hidden="true" />
          <div className="relic-detail__poster">
            {relic.urlImage ? (
              <img src={relic.urlImage} alt={relic.name} />
            ) : (
              <div className="relic-detail__no-image">?</div>
            )}
          </div>
        </div>

        <div className="relic-detail__meta">
          <span className="relic-detail__badge">{rarity}</span>
          <h1 className="relic-detail__title">{relic.name}</h1>
        </div>
      </div>

      <div className="relic-detail__panel">
        <h2 className="relic-detail__section-title">Описание</h2>
        <p
          className={`relic-detail__description ${
            relic.description.trim() ? '' : 'relic-detail__description--empty'
          }`}
        >
          {relic.description.trim() || 'Описание не указано'}
        </p>
      </div>

      <div className="relic-detail__panel relic-detail__panel--characters">
        <h2 className="relic-detail__section-title">Подходит персонажам</h2>
        <div className="relic-detail__characters">
          {characterLabels.map((label) => (
            <span
              key={label}
              className={`relic-detail__character ${
                label === 'Все персонажи' ? 'relic-detail__character--all' : ''
              }`}
            >
              {label}
            </span>
          ))}
        </div>
      </div>

      {error && <p className="relic-list__status relic-list__status--error">{error}</p>}

      <button
        type="button"
        className="relic-detail__delete"
        onClick={handleDelete}
        disabled={deleting}
      >
        {deleting ? 'Удаление...' : 'Удалить реликвию'}
      </button>
    </section>
  )
}

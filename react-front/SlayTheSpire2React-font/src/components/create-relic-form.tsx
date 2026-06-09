import { useState, type FormEvent } from 'react'
import { ALL_CHARACTERS_VALUE, CHARACTER_OPTIONS } from '../constants/characters'
import { createRelic } from '../services/relic-service'
import type { Relic } from '../types/relic'
import { formatRelicCharacters } from '../utils/relic-characters'
import { RelicCard } from './relic-card'

interface CreateRelicFormProps {
  onCreated: (relic: Relic) => void
}

const RARITY_OPTIONS = [
  'Starter Relic',
  'Common Relic',
  'Uncommon Relic',
  'Rare Relic',
  'Boss Relic',
  'Shop Relic',
] as const

export const CreateRelicForm = function ({ onCreated }: CreateRelicFormProps) {
  const [isOpen, setIsOpen] = useState(false)
  const [name, setName] = useState('')
  const [urlImage, setUrlImage] = useState('')
  const [description, setDescription] = useState('')
  const [rarity, setRarity] = useState<string>(RARITY_OPTIONS[1])
  const [allCharacters, setAllCharacters] = useState(true)
  const [selectedCharacters, setSelectedCharacters] = useState<string[]>([])
  const [submitting, setSubmitting] = useState(false)
  const [error, setError] = useState<string | null>(null)

  const previewCharacters = allCharacters
    ? ALL_CHARACTERS_VALUE
    : formatRelicCharacters(selectedCharacters)

  const previewRelic: Relic = {
    id: 0,
    name: name || 'Название реликвии',
    urlImage,
    rarity: rarity || 'Common Relic',
    description: description || 'Описание реликвии',
    characters: previewCharacters,
  }

  const handleAllCharactersToggle = () => {
    setAllCharacters(true)
    setSelectedCharacters([])
  }

  const handleCharacterToggle = (character: string) => {
    setAllCharacters(false)

    setSelectedCharacters((current) => {
      const next = current.includes(character)
        ? current.filter((item) => item !== character)
        : [...current, character]

      if (next.length === CHARACTER_OPTIONS.length) {
        setAllCharacters(true)
        return []
      }

      return next
    })
  }

  const resetForm = () => {
    setName('')
    setUrlImage('')
    setDescription('')
    setRarity(RARITY_OPTIONS[1])
    setAllCharacters(true)
    setSelectedCharacters([])
  }

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()

    if (!allCharacters && selectedCharacters.length === 0) {
      setError('Выберите хотя бы одного персонажа или «Все персонажи»')
      return
    }

    setSubmitting(true)
    setError(null)

    try {
      const relic = await createRelic({
        name,
        urlImage,
        rarity,
        description,
        characters: allCharacters
          ? ALL_CHARACTERS_VALUE
          : formatRelicCharacters(selectedCharacters),
      })
      onCreated(relic)

      resetForm()
      setIsOpen(false)
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Не удалось создать реликвию')
    } finally {
      setSubmitting(false)
    }
  }

  return (
    <div className={`create-relic-form ${isOpen ? 'create-relic-form--open' : ''}`}>
      <button
        type="button"
        className="create-relic-form__toggle"
        onClick={() => setIsOpen((open) => !open)}
        aria-expanded={isOpen}
      >
        <span className="create-relic-form__toggle-content">
          <span className="create-relic-form__emblem" aria-hidden="true">
            ✦
          </span>
          <span className="create-relic-form__toggle-text">
            <span className="create-relic-form__toggle-title">Добавить реликвию</span>
            <span className="create-relic-form__toggle-subtitle">
              {isOpen ? 'Скрыть форму' : 'Открыть форму создания'}
            </span>
          </span>
        </span>
        <span className="create-relic-form__chevron" aria-hidden="true" />
      </button>

      <div className="create-relic-form__dropdown">
        <div className="create-relic-form__dropdown-inner">
          <form className="create-relic-form__content" onSubmit={handleSubmit}>
            <div className="create-relic-form__panel">
              <header className="create-relic-form__header">
                <div className="create-relic-form__intro">
                  <h3 className="create-relic-form__heading">Новая реликвия</h3>
                  <p className="create-relic-form__subtitle">
                    Добавьте артефакт в коллекцию и проверьте, как он будет выглядеть
                  </p>
                </div>
              </header>

              <div className="create-relic-form__body">
                <div className="create-relic-form__fields">
                  <label className="create-relic-form__field">
                    <span className="create-relic-form__label">Название</span>
                    <input
                      type="text"
                      value={name}
                      onChange={(event) => setName(event.target.value)}
                      placeholder="Burning Blood"
                      required
                    />
                  </label>

                  <label className="create-relic-form__field">
                    <span className="create-relic-form__label">URL изображения</span>
                    <input
                      type="url"
                      value={urlImage}
                      onChange={(event) => setUrlImage(event.target.value)}
                      placeholder="https://..."
                      required
                    />
                  </label>

                  <label className="create-relic-form__field">
                    <span className="create-relic-form__label">Описание</span>
                    <textarea
                      className="create-relic-form__description"
                      value={description}
                      onChange={(event) => setDescription(event.target.value)}
                      placeholder="At the start of each combat, gain 2 Strength."
                      rows={3}
                    />
                  </label>

                  <fieldset className="create-relic-form__rarity">
                    <legend className="create-relic-form__label">Редкость</legend>
                    <div className="create-relic-form__rarity-options">
                      {RARITY_OPTIONS.map((option) => (
                        <button
                          key={option}
                          type="button"
                          className={`create-relic-form__rarity-chip ${
                            rarity === option ? 'create-relic-form__rarity-chip--active' : ''
                          }`}
                          onClick={() => setRarity(option)}
                        >
                          {option.replace(' Relic', '')}
                        </button>
                      ))}
                    </div>
                  </fieldset>

                  <fieldset className="create-relic-form__characters">
                    <legend className="create-relic-form__label">Персонажи</legend>
                    <div className="create-relic-form__rarity-options">
                      <button
                        type="button"
                        className={`create-relic-form__rarity-chip ${
                          allCharacters ? 'create-relic-form__rarity-chip--active' : ''
                        }`}
                        onClick={handleAllCharactersToggle}
                      >
                        Все персонажи
                      </button>
                      {CHARACTER_OPTIONS.map((character) => (
                        <button
                          key={character}
                          type="button"
                          className={`create-relic-form__rarity-chip ${
                            !allCharacters && selectedCharacters.includes(character)
                              ? 'create-relic-form__rarity-chip--active'
                              : ''
                          }`}
                          onClick={() => handleCharacterToggle(character)}
                        >
                          {character}
                        </button>
                      ))}
                    </div>
                  </fieldset>

                  {error && <p className="create-relic-form__error">{error}</p>}

                  <button
                    type="submit"
                    className="create-relic-form__submit"
                    disabled={submitting}
                  >
                    {submitting ? 'Сохранение...' : 'Создать реликвию'}
                  </button>
                </div>

                <aside className="create-relic-form__preview">
                  <span className="create-relic-form__preview-label">Превью</span>
                  <div className="create-relic-form__preview-stage">
                    <RelicCard relic={previewRelic} linkable={false} />
                  </div>
                </aside>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}

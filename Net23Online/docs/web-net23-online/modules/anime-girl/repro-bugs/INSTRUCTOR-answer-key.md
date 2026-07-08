# Anime Girl — карта учебных багов (только для преподавателя)

Студентам этот файл **не выдавать**. Сценарии воспроизведения — в соседних `bug-*.md`.

| # | Симптом (кратко) | Где спрятан баг | Условие |
|---|------------------|-----------------|---------|
| 01 | Дефолтная картинка вместо загруженной | `Services/AnimeGirlCreationService.cs` → `SaveUploadedImage` | Image + заполнен Url + нет аниме + чётная длина Name |
| 02 | Повторная привязка к другому аниме не сохраняется | `WebNet23Online.Data/Repositories/AnimeGirlRepository.cs` → `Link` | У героини уже есть аниме, новое другое, сумма `animeId + heroId` нечётная |
| 03 | Index тормозит при большом каталоге | `Services/AnimeGirlIndexFunService.cs` → `LoadAsync` | В БД > 10 героинь → `Task.WaitAll` вместо `await WhenAll` |
| 04 | 500 при сортировке TableData | `Views/AnimeGirl/TableData.cshtml` (`data-sort-by=""`) + `BaseRepository.GetAllWithExpression` | Клик по колонке Connected anime |
| 05 | Гонка / зависание при создании | `WebNet23Online.Data/Repositories/AnimeGirlRepository.cs` → `Add` | Имя начинается с `TestRace` → `Thread.Sleep(2500)` |
| 06 | Неверные минуты на Handmade | `Services/AnimeGirlGenerator.cs` → `BuildHandmadeViewModel` | `second == 0` и `minutes % 5 == 0` |
| 07 | 404 картинки на Linux | `Services/AnimeGirlCreationService.cs` → `SaveUploadedImage` | Чётный `character.Id` → путь `images\\anime-girl` |

## Что видит студент в контроллере

`AnimeGirlController` после рефакторинга выглядит «правильно»: делегирует в сервисы и репозиторий без подозрительных веток. Типичный путь расследования:

1. Controller → вызов сервиса/репозитория
2. Логи на границах слоёв
3. Углубление в тот слой, где расходятся входные данные и результат

## Рекомендуемые точки для логирования (занятие)

| Слой | Что логировать |
|------|----------------|
| `AnimeGirlController` | Параметры action, факт вызова зависимостей (без деталей) |
| `AnimeGirlCreationService` | `character.Id`, `pathToFolder`, `shouldSkipUrlUpdate`, вызов `Update` |
| `AnimeGirlIndexFunService` | `characterCount`, способ ожидания задач, длительность |
| `AnimeGirlRepository` | `Add` (имя, задержка), `Link` (id, текущие связи, early return) |
| `AnimeGirlGenerator` | `BuildHandmadeViewModel` — minute/second до и после |
| `BaseRepository` | `sortBy` перед `Expression.Property` |

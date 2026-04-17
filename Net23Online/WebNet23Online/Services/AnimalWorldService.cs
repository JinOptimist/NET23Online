using WebNet23Online.Data.Models.AnimalWorld;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.AnimalWorld;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class AnimalWorldService : IAnimalWorldService
    {
        public const int START_PAGE_COUNT_ANIMALS = 2;
        public const string CANT_FIND_ANIMAL = "Не получается найти такое животное. Попробуйте изменить запрос.";
        private IAnimalWorldRepository _animalWorldRepository;

        public AnimalWorldService(IAnimalWorldRepository animalWorldRepository)
        {
            _animalWorldRepository = animalWorldRepository;
        }

        public StartPageAnimalsViewModel GetAllAnimals()
        {
            
            var animals = GetAllBeastsFromDatabase();
            var startPageAnimals = new StartPageAnimalsViewModel
            {
                Animals = animals,
                Beast = null,
            };
            return startPageAnimals;
        }

        public StartPageAnimalsViewModel GetRandomAnimals()
        {
            var animals = GetAllBeastsFromDatabase();
            var copy = animals.ToArray();
            Random.Shared.Shuffle(copy);
            var startPageAnimalsList = copy.Take(START_PAGE_COUNT_ANIMALS).ToList();
            var startPageAnimals = new StartPageAnimalsViewModel
            {
                Animals = startPageAnimalsList,
                Beast = null,
            };
            return startPageAnimals;
        }

        public bool AddAnimal(AnimalSpeciesViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.BeastName)
                || string.IsNullOrEmpty(viewModel.BriefDescription)
                || string.IsNullOrEmpty(viewModel.BriefDescription)
                || string.IsNullOrEmpty(viewModel.FullDescription))
            {
                return false;
            }

            if (!_animalWorldRepository.IsExists(viewModel.BeastName))
            {
                AnimalSpeciesData beastData = new AnimalSpeciesData
                {
                    AnimalSpeciesName = viewModel.BeastName,
                    AnimalFamilyName = viewModel.NativeRange,
                    NativeRange = viewModel.BriefDescription,
                    Description = viewModel.FullDescription,
                };
                _animalWorldRepository.Add(beastData);
            }

            return true;
        }

        public AnimalSpeciesViewModel SearchAnimal(AnimalSpeciesViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.BeastName))
            {
                return null;
            }

            var beastSearch = new AnimalSpeciesViewModel();
            if (!_animalWorldRepository.IsExists(viewModel.BeastName))
            {
                beastSearch.NativeRange = CANT_FIND_ANIMAL;
                beastSearch.FullDescription = CANT_FIND_ANIMAL;
            }
            else
            {
                var beastDataSearch = _animalWorldRepository.GetBeastByName(viewModel.BeastName);
                beastSearch.BeastName = beastDataSearch.AnimalSpeciesName;
                beastSearch.NativeRange = beastDataSearch.AnimalFamilyName;
                beastSearch.FullDescription = beastDataSearch.Description;
            }

            return beastSearch;
        }

        private List<AnimalSpeciesViewModel> GetAllBeastsFromDatabase()
        {
            var beastsData = _animalWorldRepository.GetAll();
            var beasts = beastsData.Select(animal => new AnimalSpeciesViewModel
            {
                BeastName = animal.AnimalSpeciesName,
                NativeRange = animal.AnimalFamilyName,
                BriefDescription = animal.NativeRange,
                FullDescription = animal.Description,
            });
            return beasts.ToList();
        }
    }
}

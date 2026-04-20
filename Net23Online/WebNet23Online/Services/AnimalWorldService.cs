using WebNet23Online.Data.Models;
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

        public bool AddAnimal(StartPageBeastViewModel viewModel)
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
                BeastData beastData = new BeastData
                {
                    BeastName = viewModel.BeastName,
                    NativeRange = viewModel.NativeRange,
                    BriefDescription = viewModel.BriefDescription,
                    FullDescription = viewModel.FullDescription,
                };
                _animalWorldRepository.Add(beastData);
            }

            return true;
        }

        public StartPageBeastViewModel SearchAnimal(StartPageBeastViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.BeastName))
            {
                return null;
            }

            var beastSearch = new StartPageBeastViewModel();
            if (!_animalWorldRepository.IsExists(viewModel.BeastName))
            {
                beastSearch.NativeRange = CANT_FIND_ANIMAL;
                beastSearch.FullDescription = CANT_FIND_ANIMAL;
            }
            else
            {
                var beastDataSearch = _animalWorldRepository.GetBeastByName(viewModel.BeastName);
                beastSearch.BeastName = beastDataSearch.BeastName;
                beastSearch.NativeRange = beastDataSearch.NativeRange;
                beastSearch.FullDescription = beastDataSearch.FullDescription;
            }

            return beastSearch;
        }

        private List<StartPageBeastViewModel> GetAllBeastsFromDatabase()
        {
            var beastsData = _animalWorldRepository.GetAll();
            var beasts = beastsData.Select(animal => new StartPageBeastViewModel
            {
                BeastName = animal.BeastName,
                NativeRange = animal.NativeRange,
                BriefDescription = animal.BriefDescription,
                FullDescription = animal.FullDescription,
            });
            return beasts.ToList();
        }
    }
}

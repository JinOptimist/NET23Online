using Microsoft.AspNetCore.Mvc.Rendering;
using WebNet23Online.Data.Models.AnimalWorld;
using WebNet23Online.Data.Repositories.Interfaces.AnimalWorld;
using WebNet23Online.Models.AnimalWorld;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class AnimalWorldService : IAnimalWorldService
    {
        private IZooRepository _zooRepository;
        private IAnimalFamilyRepository _animalFamilyRepository;
        private IAnimalSpeciesRepository _animalSpeciesRepository;
        private IAnimalWorldMapper _animalWorldMapper;

        public AnimalWorldService(IZooRepository zooRepository, IAnimalFamilyRepository animalFamilyRepository, IAnimalSpeciesRepository animalSpeciesRepository, IAnimalWorldMapper animalWorldMapper)
        {
            _zooRepository = zooRepository;
            _animalFamilyRepository = animalFamilyRepository;
            _animalSpeciesRepository = animalSpeciesRepository;
            _animalWorldMapper = animalWorldMapper;
        }

        public StartPageAnimalWorldInfoViewModel GetStartInfo()
        {
            var zoos = _animalWorldMapper.FromZooDataToZooViewModel(_zooRepository.GetRandomElements());
            var animalFamilies = _animalWorldMapper.FromAnimalFamilyDataToAnimalFamilyViewModel(_animalFamilyRepository.GetRandomElements());
            var animalSpecies = _animalWorldMapper.FromAnimalSpeciesDataToAnimalSpeciesViewModel(_animalSpeciesRepository.GetRandomElements());
            var startPageInfo = new StartPageAnimalWorldInfoViewModel
            {
                Zoos = zoos,
                AnimalFamilies = animalFamilies,
                AnimalSpecies = animalSpecies,
            };
            return startPageInfo;
        }

        public AnimalSpeciesViewModel GetAnimalSpeciesPageInfo()
        {
            var animalFamilies = GetAnimalFamilies();
            var animalFamilyListItems = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Выберите род животного",
                    Value = ""
                }
            };
            animalFamilyListItems.AddRange(animalFamilies.Select(animalFamily => new SelectListItem
            {
                Text = animalFamily.AnimalFamilyName,
                Value = animalFamily.Id.ToString()
            }));
            var viewModel = new AnimalSpeciesViewModel
            {
                AnimalFamilyNames = animalFamilyListItems
            };

            return viewModel;
        }

        private List<AnimalFamilyData> GetAnimalFamilies()
        {
            return _animalFamilyRepository.GetAll();
        }

        public bool AddZoo(ZooViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.ZooName)
                || string.IsNullOrEmpty(viewModel.Address)
                || string.IsNullOrEmpty(viewModel.Description))
            {
                return false;
            }

            if (_zooRepository.GetElementByName(viewModel.ZooName) == null)
            {
                ZooData zooData = new ZooData
                {
                    ZooName = viewModel.ZooName,
                    Address = viewModel.Address,
                    Description = viewModel.Description
                };
                _zooRepository.Add(zooData);
            }

            return true;
        }

        public bool AddAnimalFamily(AnimalFamilyViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.AnimalFamilyName)
                || string.IsNullOrEmpty(viewModel.Description))
            {
                return false;
            }

            if (_animalFamilyRepository.GetElementByName(viewModel.AnimalFamilyName) == null)
            {
                AnimalFamilyData animalFamilyData = new AnimalFamilyData
                {
                    AnimalFamilyName = viewModel.AnimalFamilyName,
                    Description = viewModel.Description
                };
                _animalFamilyRepository.Add(animalFamilyData);
            }

            return true;
        }

        public bool AddAnimalSpecies(AnimalSpeciesViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.AnimalSpeciesName)
                || string.IsNullOrEmpty(viewModel.Description))
            {
                return false;
            }

            if (_animalSpeciesRepository.GetElementByName(viewModel.AnimalSpeciesName) == null)
            {
                AnimalSpeciesData animalSpeciesData = new AnimalSpeciesData
                {
                    AnimalSpeciesName = viewModel.AnimalSpeciesName,
                    NativeRange = viewModel.NativeRange,
                    Description = viewModel.Description
                };
                _animalSpeciesRepository.Add(animalSpeciesData);
            }

            return true;
        }
    }
}

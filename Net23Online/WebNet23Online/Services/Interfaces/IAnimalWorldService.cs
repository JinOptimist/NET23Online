using WebNet23Online.Models.AnimalWorld;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAnimalWorldService
    {
        public StartPageAnimalsViewModel GetAllAnimals();
        StartPageAnimalsViewModel GetRandomAnimals();
        bool AddAnimal(AnimalSpeciesViewModel viewModel);
        AnimalSpeciesViewModel SearchAnimal(AnimalSpeciesViewModel viewModel);
    }
}
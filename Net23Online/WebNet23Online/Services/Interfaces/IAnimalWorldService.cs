using WebNet23Online.Models.AnimalWorld;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAnimalWorldService
    {
        public StartPageAnimalsViewModel GetAllAnimals();
        StartPageAnimalsViewModel GetRandomAnimals();
        bool AddAnimal(StartPageBeastViewModel viewModel);
        StartPageBeastViewModel SearchAnimal(StartPageBeastViewModel viewModel);
    }
}
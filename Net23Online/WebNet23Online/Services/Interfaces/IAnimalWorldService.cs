using WebNet23Online.Models.AnimalWorld;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAnimalWorldService
    {
        bool AddAnimal(StartPageBeastViewModel viewModel);
        StartPageAnimalsViewModel GetRandomAnimals();
        StartPageBeastViewModel SearchAnimal(StartPageBeastViewModel viewModel);
    }
}
using WebNet23Online.Data.Models.AnimalWorld;
using WebNet23Online.Models.AnimalWorld;

namespace WebNet23Online.Services.Interfaces
{
    public interface IAnimalWorldService
    {
        public StartPageAnimalWorldInfoViewModel GetStartInfo();

        public AnimalSpeciesViewModel GetAnimalSpeciesPageInfo();

        bool AddZoo(ZooViewModel viewModel);

        bool AddAnimalFamily(AnimalFamilyViewModel viewModel);

        bool AddAnimalSpecies(AnimalSpeciesViewModel viewModel);
    }
}
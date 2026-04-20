using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces.AnimalWorld
{
    public interface IAnimalWorldRepository<DataModel> : IBaseRepository<DataModel> where DataModel : BaseModel
    {
        List<DataModel> GetRandomElements();

        DataModel GetElementByName(string name);
    }
}

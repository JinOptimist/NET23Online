using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces.AnimalWorld
{
    public interface IAnimalWorldRepository<DataModel> : IBaseRepository<DataModel>, INameCheckable where DataModel : BaseModel
    {
        List<DataModel> GetRandomElements();

        new DataModel GetElementByName(string name);
    }
}

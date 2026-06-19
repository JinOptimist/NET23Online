using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces.AnimalWorld
{
    public interface INameableRepository<DataModel> where DataModel : BaseModel
    {
        DataModel GetElementByName(string name);
    }
}

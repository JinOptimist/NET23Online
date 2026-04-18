using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IBaseRepository<DataModel>
        where DataModel : BaseModel
    {
        void Add(DataModel model);
        List<DataModel> GetAll();
        void Remove(DataModel model);
        bool Any();
        DataModel? Get(int id);
        void UpdateData(DataModel model);
    }
}
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IDataUserForMaksKorzRepository
    {
        void Add(DataUserForMaksKorz model);
        List<DataUserForMaksKorz> GetAll();
        void Removed(DataUserForMaksKorz model);
        bool Contains(DataUserForMaksKorz model);
    }
}
using WebNet23Online.Data.Models.MaksKorz;

namespace WebNet23Online.Data.Repositories.MaksKorz
{
    public interface IDataUserForMaksKorzRepository
    {
        void Add(DataUserForMaksKorz model);
        List<DataUserForMaksKorz> GetAll();
        void Removed(DataUserForMaksKorz model);
        bool Contains(DataUserForMaksKorz model);
    }
}
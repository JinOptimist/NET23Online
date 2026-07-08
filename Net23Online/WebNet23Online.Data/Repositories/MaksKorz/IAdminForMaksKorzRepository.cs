using WebNet23Online.Data.Models;
using WebNet23Online.Data.Models.MaksKorz;

namespace WebNet23Online.Data.Repositories.MaksKorz
{
    public interface IAdminForMaksKorzRepository
    {
        public DataUserForMaksKorz? GetByNameAndPassword(string login, string password);
        public DataUserForMaksKorz? Get(int id);
        public DataUserForMaksKorz GetFirst();
        public List<DataUserForMaksKorz> GetAll();
    }
}
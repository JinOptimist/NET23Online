using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Models.MaksKorz;

namespace WebNet23Online.Data.Repositories.MaksKorz
{
    public class AdminForMaksKorzRepository : IAdminForMaksKorzRepository
    {
        private DbSet<DataUserForMaksKorz> _dbSet;
        private WebContext _context;
        public virtual DataUserForMaksKorz? Get(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
        public DataUserForMaksKorz GetFirst()
        {
            return _dbSet.First();
        }
        public virtual List<DataUserForMaksKorz> GetAll()
        {
            return _dbSet.ToList();
        }
        public AdminForMaksKorzRepository(WebContext context)
        {
            _context = context;
            _dbSet = _context.Set<DataUserForMaksKorz>();
        }
        public DataUserForMaksKorz? GetByNameAndPassword(string login, string password)
        {
            return _dbSet
               .FirstOrDefault(x => x.LastName == login && x.Password == password);
        }

    }
}

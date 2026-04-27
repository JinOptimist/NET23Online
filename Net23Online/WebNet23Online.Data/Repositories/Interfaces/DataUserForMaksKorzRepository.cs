using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public class DataUserForMaksKorzRepository : IDataUserForMaksKorzRepository
    {
        private WebContext _webContext;
        public DataUserForMaksKorzRepository(WebContext webContext)
        {
            _webContext = webContext;
        }
        public void Add(DataUserForMaksKorz model)
        {
            _webContext.Add(model);
            _webContext.SaveChanges();
        }
        public void Removed(DataUserForMaksKorz model)
        {
            _webContext.Remove(model);
            _webContext.SaveChanges();
        }
        public List<DataUserForMaksKorz> GetAll()
        {
            return _webContext.DataUserMK.ToList();
        }
        public bool Contains(DataUserForMaksKorz model)
        {
            return _webContext.DataUserMK.Any(x => x.LastName == model.LastName);
        }
    }
}

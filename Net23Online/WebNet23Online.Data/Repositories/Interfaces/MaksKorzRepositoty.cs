using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public class MaksKorzRepositoty : BaseRepository<DataUserData>, IMaksKorzRepositoty
    {
        public MaksKorzRepositoty(WebContext context) : base(context)
        {

        }

        public override void Add(DataUserData model)
        {
            if (model.Name == model.LastName)
            {
                throw new Exception("Be more creative");
            }
            base.Add(model);
        }

        public void Link(int nameId, int heroId)
        {
            var Maks = _context.DataUser.First(x => x.Id == nameId);
            Maks.User.Add(Maks);
            _context.SaveChanges();
        }

        public void Remove(DataUserData model)
        {
            throw new NotImplementedException();
        }

        public void Update(DataUserData model)
        {
            throw new NotImplementedException();
        }



        List<DataUserData> IBaseRepository<DataUserData>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}


using lts.Data.Abstract;
using lts.Data.Concrete;
using lts.Data.Concrete.Context;
using lts.domain.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DAL.Concrete
{
    public class KullaniciRepository : GenericRepository<Kullanıcı>, IKullaniciRepository
    {
        private myDataContext _dt;
        public KullaniciRepository(myDataContext dt) : base(dt)
        {
            _dt = new myDataContext();
        }
        public async Task<Kullanıcı> kullanicigetir(int id)
        {
            var deger = await _dt.Kullanıcıs.Include(x => x.UserID).Include(x => x.KullanıcıAdi).Include(x => x.Sifre).Where(x => x.UserID == id).FirstOrDefaultAsync();
            return deger;
        }

        public async Task<List<Kullanıcı>> kullanicilariGetir()
        {
            return await _dt.Kullanıcıs.Include(x => x.Ad).Include(x => x.SoyAd).Include(x => x.TelefonNo).Include(x => x.Email).Include(x => x.Sifre).Include(x => x.UserID).Where(x => x.Silindi == false).ToListAsync();
        }
    }
}

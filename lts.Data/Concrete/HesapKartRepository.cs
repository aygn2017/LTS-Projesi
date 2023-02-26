
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
    public class HesapKartRepository : GenericRepository<HesapKartı>, IHesapKartRepository
    {
        private myDataContext _dt;
        public HesapKartRepository(myDataContext dt) : base(dt)
        {
            _dt = new myDataContext();
        }

    
        public async Task<List<HesapKartı>> HesapKartGetir()
        {
            return await _dt.HesapKartıs.Include(x => x.Unvan).Include(x => x.VergiDairesi).Include(x => x.vergiNo).Include(x => x.TCNO).Include(x => x.Adres).Where(x => x.Silindi == false).ToListAsync();
        }

        public async Task<HesapKartı> HesapKartGoster(int id)
        {
            return await _dt.HesapKartıs.Include(x => x.Unvan).Include(x => x.VergiDairesi).Include(x => x.vergiNo).Include(x => x.TCNO).Include(x => x.Adres).Where(x=>x.Silindi==false&&x.KartID==id).FirstOrDefaultAsync();
        }

        public async Task<int> HesapKartiEkle(HesapKartı tlp)
        {
            tlp.Silindi = false;
            await _dt.HesapKartıs.AddAsync(tlp);
       
            return await _dt.SaveChangesAsync();
        }

       
    }
}


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
    public class HesapKartTurRepository : GenericRepository<HesapKartTur>, IHesapKartTurRepository
    {
        private myDataContext _dt; 
        public HesapKartTurRepository(myDataContext dt) : base(dt)
        {

                _dt = new myDataContext();
        }

        public async Task<int> HesapKartTuruEkle(HesapKartTur tlp)
        {
            tlp.Silindi = false;

            await _dt.HesapKartTurs.AddAsync(tlp);
            return await _dt.SaveChangesAsync();
        }

        public async Task<HesapKartTur> HesapKarturuGoster(int id)
        {
            return await _dt.HesapKartTurs.Include(x => x.TurAdi).Include(x => x.TurID).Where(x => x.Silindi == false && x.TurID == id).FirstOrDefaultAsync();
        }

        public  async Task<List<HesapKartTur>> HesapKartTuruGetir()
        { 
            return await _dt.HesapKartTurs.Where(x => x.Silindi == false).ToListAsync();
        }
    }
}

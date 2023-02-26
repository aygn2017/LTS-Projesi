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
    public class HesapKartTipiRepository : GenericRepository<HesapKartTip>, IHesapKartTipRepository
    {
        private myDataContext _dt;
        public HesapKartTipiRepository(myDataContext dt) : base(dt)
        {
            _dt = new myDataContext();
        }

        public async Task<int> HesapKartTipiEkle(HesapKartTip tlp)
        {
            tlp.Silindi = false;
        
            await _dt.HesapKartTips.AddAsync(tlp);
            return await _dt.SaveChangesAsync();

        }
        public async Task<List<HesapKartTip>> HesapKartTipiGetir()
        {
            return await _dt.HesapKartTips.Where(x => x.Silindi == false).ToListAsync();
        }

        public async Task<HesapKartTip> HesapKartTipiGoster(int id)
        {
            return await _dt.HesapKartTips.Include(x => x.TipAdi).Include(x => x.TipID).Where(x => x.Silindi == false && x.TipID == id).FirstOrDefaultAsync();
        }
    }
}

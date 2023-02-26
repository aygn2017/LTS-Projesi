
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
    public class HesapKartGrupRepository : GenericRepository<HesapKartGrup>, IHesapKartGrupRepository
    {
        private myDataContext _dt;
        public HesapKartGrupRepository(myDataContext dt) : base(dt)
        {
            _dt = new myDataContext();
        }

        public async Task<int> HesapKartGrubuEkle(HesapKartGrup tlp)
        {
            tlp.Silindi = false;
            await _dt.HesapKartGrups.AddAsync(tlp);
            return await _dt.SaveChangesAsync();
        }

        public async Task<HesapKartGrup> HesapKartGrubuGoster(int id)
        {
            return await _dt.HesapKartGrups.Include(x => x.GrupAdi).Include(x => x.KartGrupID).Where(x => x.Silindi == false && x.KartGrupID == id).FirstOrDefaultAsync();
        }

       
        public async Task<List<HesapKartGrup>> HesapKartGruplariGetir()
        {
            return await _dt.HesapKartGrups.Where(x => x.Silindi == false ).ToListAsync();
        }
    }
}

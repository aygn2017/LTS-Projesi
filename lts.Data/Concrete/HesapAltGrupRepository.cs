
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
    public class HesapAltGrupRepository:GenericRepository<HesapAltGrup>,IHesapAltGrupRepository
    {

        private myDataContext _dt;

        public HesapAltGrupRepository(myDataContext dt):base(dt)
        {
            _dt = new myDataContext();
        }

        public async Task<int> HesapAltGrubuEkle(HesapAltGrup hag)
        {

            hag.Silindi = false;
            await _dt.HesapAltGrups.AddAsync(hag);
            return await _dt.SaveChangesAsync();
        }

        public async Task<HesapAltGrup> HesapAltGrubuGoster(int id)
        {
            return await _dt.HesapAltGrups.Include(x => x.AltGrupID).Where(x => x.Silindi == false && x.AltGrupID == id).FirstOrDefaultAsync();
        }

        public async Task<List<HesapAltGrup>> HesapAltGrupGetir()
        {
            return await _dt.HesapAltGrups.Where(x => x.Silindi == false).ToListAsync();
        }
        public async Task<List<HesapAltGrup>> HesapAltGruplariGetir()
        {
            try
            {
                return await _dt.HesapAltGrups.Include(x => x.GrupAdi).Include(x => x.AltGrupID).Where(x => x.Silindi == false).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}

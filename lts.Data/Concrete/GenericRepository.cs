using lts.Data.Abstract;
using lts.Data.Concrete.Context;
using lts.domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.Data.Concrete
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : class, ITablo, new()
    {

        private myDataContext _dt;
        public GenericRepository(myDataContext dt)
        {
            _dt = dt;
        }
        public async Task<int> Create(Tentity ent)
        {

            ent.Silindi = false;
            await _dt.Set<Tentity>().AddAsync(ent);
            return await _dt.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {

            var obje = await _dt.Set<Tentity>().FindAsync(id);
            obje.Silindi = true;
            _dt.Update(obje);
            var sonuc = await _dt.SaveChangesAsync();
            return sonuc;
        }

        public async Task<List<Tentity>> Get()
        {

            return await _dt.Set<Tentity>().Where(x => x.Silindi == false).ToListAsync();
        }

        public async Task<Tentity> GetById(int id)
        {

            var obje = await _dt.Set<Tentity>().FindAsync(id);
            return obje;
        }

        public async Task<int> Update(Tentity ent)
        {

            _dt.Set<Tentity>().Update(ent);
            return await _dt.SaveChangesAsync();
        }
    }
}
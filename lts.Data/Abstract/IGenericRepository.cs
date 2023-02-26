using lts.domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.Data.Abstract
{
    public interface IGenericRepository<Tentity> where Tentity : class, ITablo, new()
    {
        Task<List<Tentity>> Get();
        Task<int> Create(Tentity ent);
        Task<int> Update(Tentity ent);
        Task<int> Delete(int id);
        Task<Tentity> GetById(int id);
    }
}

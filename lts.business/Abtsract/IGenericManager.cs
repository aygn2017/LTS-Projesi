using lts.domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Abtsract
{
    public interface IGenericManager<TEntity> where TEntity : class, ITablo, new()
    {
        Task<List<TEntity>> Get();
        Task<int> Create(TEntity ent);
        Task<int> Update(TEntity ent);
        Task<int> Delete(int id);
        Task<TEntity> GetById(int id);
    }
}

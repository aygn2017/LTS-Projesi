using lts.business.Abtsract;
using lts.Data.Abstract;
using lts.domain.Interface;
using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Concrete
{
    public class GenericManager<TEntity> : IGenericManager<TEntity> where TEntity : class, ITablo, new()
    {

        IGenericRepository<TEntity> _repository;


        public GenericManager(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(TEntity ent)
        {
            return await _repository.Create(ent);
        }

        public async Task<int> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<TEntity>> Get()
        {
            return await _repository.Get();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<int> Update(TEntity ent)
        {
            return await _repository.Update(ent);
        }
    }
}
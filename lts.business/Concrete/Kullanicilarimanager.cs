using lts.business.Abtsract;
using lts.Data.Abstract;
using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Concrete
{
    public class Kullanicilarimanager : GenericManager<Kullanıcı>, IKullaniciManager
    {
        private readonly IKullaniciRepository kullaniciRepository;
        public Kullanicilarimanager(IGenericRepository<Kullanıcı> repository, IKullaniciRepository repository1) : base(repository)
        {
            kullaniciRepository = repository1;
        }

        public async Task<List<Kullanıcı>> kullanicilariGetir()
        {
            return await kullaniciRepository.kullanicilariGetir();
        }

        public async Task<Kullanıcı> KullanicilariGetir(int id)
        {
            return await kullaniciRepository.kullanicigetir(id);
        }
    }
}
using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.Data.Abstract
{
    public interface IKullaniciRepository : IGenericRepository<Kullanıcı>
    {


        Task<Kullanıcı> kullanicigetir(int id);
        Task<List<Kullanıcı>> kullanicilariGetir();

    }
}

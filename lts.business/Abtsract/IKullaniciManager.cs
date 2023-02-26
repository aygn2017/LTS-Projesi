using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Abtsract
{
    public interface IKullaniciManager : IGenericManager<Kullanıcı>
    {
        Task<List<Kullanıcı>> kullanicilariGetir();
        Task<Kullanıcı> KullanicilariGetir(int id);

    }
}

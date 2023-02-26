using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Abtsract
{
    public interface IHesapKartGrupManager : IGenericManager<HesapKartGrup>
    {

        Task<List<HesapKartGrup>> HesapKartGruplariGetir();
        Task<int> HesapKartGrubuEkle(HesapKartGrup tlp);
        Task<HesapKartGrup> HesapKartGrubuGoster(int id);
    }
}

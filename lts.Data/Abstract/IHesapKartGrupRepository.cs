using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.Data.Abstract
{
    public interface IHesapKartGrupRepository : IGenericRepository<HesapKartGrup>
    {

        Task<int> HesapKartGrubuEkle(HesapKartGrup tlp);
        Task<HesapKartGrup> HesapKartGrubuGoster(int id);
        Task<List<HesapKartGrup>> HesapKartGruplariGetir();
    }
}

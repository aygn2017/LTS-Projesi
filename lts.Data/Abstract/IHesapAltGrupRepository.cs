using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.Data.Abstract
{
    public interface IHesapAltGrupRepository : IGenericRepository<HesapAltGrup>
    {
        Task<List<HesapAltGrup>> HesapAltGruplariGetir();
        Task<int> HesapAltGrubuEkle(HesapAltGrup tlp);
        Task<HesapAltGrup> HesapAltGrubuGoster(int id);
        Task<List<HesapAltGrup>> HesapAltGrupGetir();

    }
}

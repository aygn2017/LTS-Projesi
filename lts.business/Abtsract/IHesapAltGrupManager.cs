using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Abtsract
{
    public interface IHesapAltGrupManager : IGenericManager<HesapAltGrup>
    {

        Task<List<HesapAltGrup>> HesapAltGruplariGetir();
        Task<int> HesapAltGrubuEkle(HesapAltGrup tlp);
        Task<HesapAltGrup> HesapAltGrubuGoster(int id);
        Task<int> Create(HesapAltGrup hesapAltGrup);
        Task<List<HesapAltGrup>> HesapAltGrupGetir();
    }
}

using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Abtsract
{
    public interface IHesapKartTipManager : IGenericManager<HesapKartTip>
    {
        Task<List<HesapKartTip>> HesapKartTipiGetir();
        Task<int> HesapKartTipiEkle(HesapKartTip tlp);
        Task<HesapKartTip> HesapKartTipiGoster(int id);
    }
}

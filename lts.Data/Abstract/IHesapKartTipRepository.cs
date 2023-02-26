using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.Data.Abstract
{
    public interface IHesapKartTipRepository : IGenericRepository<HesapKartTip>
    {

        Task<int> HesapKartTipiEkle(HesapKartTip tlp);
        Task<HesapKartTip> HesapKartTipiGoster(int id);
        Task<List<HesapKartTip>> HesapKartTipiGetir();
    }
}

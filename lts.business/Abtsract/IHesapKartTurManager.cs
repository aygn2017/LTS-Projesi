using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Abtsract
{

    public interface IHesapKartTurManager : IGenericManager<HesapKartTur>
    {

        Task<List<HesapKartTur>> HesapKartTuruGetir();
        Task<int> HesapKartTuruEkle(HesapKartTur tlp);
        Task<HesapKartTur> HesapKarturuGoster(int id);
    }
}

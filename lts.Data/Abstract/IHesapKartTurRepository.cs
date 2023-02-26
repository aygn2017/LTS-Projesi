using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.Data.Abstract
{
    public interface IHesapKartTurRepository : IGenericRepository<HesapKartTur>
    {

        Task<int> HesapKartTuruEkle(HesapKartTur tlp);
        Task<HesapKartTur> HesapKarturuGoster(int id);
        Task<List<HesapKartTur>> HesapKartTuruGetir();
    }
}

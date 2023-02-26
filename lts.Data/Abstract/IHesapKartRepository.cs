using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.Data.Abstract
{
    public interface IHesapKartRepository : IGenericRepository<HesapKartı>
    {
        Task<List<HesapKartı>> HesapKartGetir();
        Task<int> HesapKartiEkle(HesapKartı tlp);
        Task<HesapKartı> HesapKartGoster(int id);

    }
}

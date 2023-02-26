using lts.business.Abtsract;
using lts.Data.Abstract;
using lts.domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Concrete
{
    public class HesapKartTipManager : GenericManager<HesapKartTip>, IHesapKartTipManager
    {
        private readonly IHesapKartTipRepository hesapKartTipRepository;
        public HesapKartTipManager( IHesapKartTipRepository repository) : base(repository)
        {
            hesapKartTipRepository = repository;
        }

        public Task<int> HesapKartTipiEkle(HesapKartTip tlp)
        {
            return hesapKartTipRepository.HesapKartTipiEkle(tlp);
        }

        public async Task<List<HesapKartTip>> HesapKartTipiGetir()
        {
            return await hesapKartTipRepository.HesapKartTipiGetir();
        }

        public Task<HesapKartTip> HesapKartTipiGoster(int id)
        {
            return hesapKartTipRepository.HesapKartTipiGoster(id);
        }
    }
}
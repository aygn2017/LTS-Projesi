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
    public class HesapKartTurManager : GenericManager<HesapKartTur>, IHesapKartTurManager
    {
        private readonly IHesapKartTurRepository hesapKartTurRepository;
        public HesapKartTurManager(IHesapKartTurRepository repository): base(repository)
        {
            hesapKartTurRepository = repository;
        }

        public async Task<List<HesapKartTur>> HesapKartTuruGetir()
        {
            return await hesapKartTurRepository.HesapKartTuruGetir();
        }

        public async Task<int> HesapKartTuruEkle(HesapKartTur tlp)
        {
            return await hesapKartTurRepository.HesapKartTuruEkle(tlp);
        }

        public  async Task<HesapKartTur> HesapKarturuGoster(int id)
        {
            return await hesapKartTurRepository.HesapKarturuGoster(id);
        }
    }
}
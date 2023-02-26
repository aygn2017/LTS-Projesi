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
    public class HesapAltGrupManager : GenericManager<HesapAltGrup>, IHesapAltGrupManager
    {

        private readonly IHesapAltGrupRepository hesapKartTipRepository;
        public HesapAltGrupManager(IHesapAltGrupRepository repository1) : base(repository1)
        {

            hesapKartTipRepository = repository1;
        }

        public  async Task<int> HesapAltGrubuEkle(HesapAltGrup tlp)
        {
            return await hesapKartTipRepository.HesapAltGrubuEkle(tlp);
        }

        public async Task<HesapAltGrup> HesapAltGrubuGoster(int id)
        {
            return await hesapKartTipRepository.HesapAltGrubuGoster(id);
        }

        public async Task<List<HesapAltGrup>> HesapAltGruplariGetir()
        {
            return await hesapKartTipRepository.HesapAltGruplariGetir();
        }
        public async Task<List<HesapAltGrup>> HesapAltGrupGetir()
        {
            return await hesapKartTipRepository.HesapAltGrupGetir();
        }
        
    }
}
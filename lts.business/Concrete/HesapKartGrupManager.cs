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
    public class HesapKartGrupManager : GenericManager<HesapKartGrup>, IHesapKartGrupManager
    {

        private readonly IHesapKartGrupRepository hesapKartGrupRepository;
        public HesapKartGrupManager(IHesapKartGrupRepository repository) : base(repository)
        {
            hesapKartGrupRepository = repository;
        }



        public async Task<int> HesapKartGrubuEkle(HesapKartGrup tlp)
        {
            return await hesapKartGrupRepository.HesapKartGrubuEkle(tlp);
        }

        public async Task<HesapKartGrup> HesapKartGrubuGoster(int id)
        {
            return await hesapKartGrupRepository.HesapKartGrubuGoster(id);
        }

        public async Task<List<HesapKartGrup>> HesapKartGruplariGetir()
        {
            return await hesapKartGrupRepository.HesapKartGruplariGetir();
        }
    }
}
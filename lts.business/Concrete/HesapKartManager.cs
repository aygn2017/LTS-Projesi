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
    public class HesapKartManager : GenericManager<HesapKartı>, IHesapKartManager
    {
        private readonly IHesapKartRepository hesapKartRepository;
        public HesapKartManager(IGenericRepository<HesapKartı> asd, IHesapKartRepository repository) : base(asd)
        {
            hesapKartRepository = repository;
        }

        public async Task<List<HesapKartı>> HesapKartGetir()
        {
            return await hesapKartRepository.HesapKartGetir();
        }

        public async Task<HesapKartı> HesapKartGoster(int id)
        {
            return await hesapKartRepository.HesapKartGoster(id);
        }

        public async Task<int> HesapKartiEkle(HesapKartı tlp)
        {
            return await hesapKartRepository.HesapKartiEkle(tlp);
        }
    }
    }


using AutoMapper;
using lts.domain.Tables;
using lts.DTOS.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<KullanicilarDTO, Kullanıcı>();
            CreateMap<Kullanıcı, KullanicilarDTO>();

            CreateMap<HesapKartTurDTO, HesapKartTur>();
            CreateMap<HesapKartTur, HesapKartTurDTO>();

            CreateMap<HesapKartTipDTO, HesapKartTip>();
            CreateMap<HesapKartTip, HesapKartTipDTO>();
            //CreateMap<List<HesapKartTip>, List<HesapKartTipDTO>>();

            CreateMap<HesapKartiDTO, HesapKartı>();
            CreateMap<HesapKartı, HesapKartiDTO>();

            CreateMap<HesapKartGrupDTO, HesapKartGrup>();
            CreateMap<HesapKartGrup, HesapKartGrupDTO>();

            CreateMap<HesapAltGrupDTO, HesapAltGrup>();
            CreateMap<HesapAltGrup, HesapAltGrupDTO>();
        }
    }
}
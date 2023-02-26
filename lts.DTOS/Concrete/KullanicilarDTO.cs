using lts.DTOS.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DTOS.Concrete
{
    public class KullanicilarDTO:IDTO
    {
        public int UserID { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string KullanıcıAdi { get; set; }
        public int Sifre { get; set; }
        public string Email { get; set; }
        public int TelefonNo { get; set; }
        public bool Silindi { get; set; }
        public string Tc { get; set; }
    }
}

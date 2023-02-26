using lts.DTOS.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DTOS.Concrete
{
    public class HesapKartGrupDTO:IDTO
    {
        public int KartGrupId { get; set; }
        public string GrupAdi { get; set; }
        public bool Silindi { get; set; }
    }
}

using lts.DTOS.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DTOS.Concrete
{
    public class HesapAltGrupDTO: IDTO
    {
        public int AltGrupID { get; set; }
        public string GrupAdi { get; set; }
        public bool Silindi { get; set; }
    }
}

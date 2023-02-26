using lts.DTOS.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DTOS.Concrete
{
    public class HesapKartTipDTO:IDTO
    {
        public int TipID { get; set; }
        public string TipAdi { get; set; }
        public bool Silindi { get; set; }
    }
}

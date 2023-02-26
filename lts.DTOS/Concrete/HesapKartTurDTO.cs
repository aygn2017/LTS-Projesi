using lts.DTOS.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DTOS.Concrete
{
    public class HesapKartTurDTO:IDTO
    {
        public int TurID { get; set; }
        public string TurAdi { get; set; }
        public bool Silindi { get; set; }
    }
}

using lts.DTOS.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DTOS.Concrete
{
    public class HesapKartiDTO:IDTO
    {

        public int KartID { get; set; }
        public string Unvan { get; set; }
        public string VergiDairesi { get; set; }
        public string vergiNo { get; set; }
        public int TCNO { get; set; }
        public string Adres { get; set; }
       
        public bool Silindi { get; set; }
    }
}

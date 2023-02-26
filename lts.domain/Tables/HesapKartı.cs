using lts.domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.domain.Tables
{
    public class HesapKartı: ITablo
    {
        [Key]
        public int KartID { get; set; }
        public string Unvan { get; set; }
        public string VergiDairesi { get; set; }
        public string vergiNo { get; set; }
        public int TCNO { get; set; }
        public string Adres { get; set; }
        public int TipID { get; set; }
        public int TurID { get; set; }
        public int KartGrupID { get; set; }
        public int AltGrupID { get; set; }
        public bool Silindi { get; set; }

        public HesapAltGrup HesapAltGrup { get; set; }
        public HesapKartGrup HesapKartGrup { get; set; }
        public HesapKartTip HesapKartTip { get; set; }
        public HesapKartTur HesapKartTur { get; set; }
   

    }
}

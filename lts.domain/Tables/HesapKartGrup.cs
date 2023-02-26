using lts.domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.domain.Tables
{
    public class HesapKartGrup: ITablo
    {
        [Key]
        public int KartGrupID { get; set; }
        public string GrupAdi { get; set; }
        public bool Silindi { get; set; }
        public List<HesapKartı> HesapKartıs { get; set; }

    }
}

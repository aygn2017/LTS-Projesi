using lts.domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.domain.Tables
{
    public class HesapKartTip: ITablo
    {
        [Key]
        public int TipID { get; set; }
        public string TipAdi { get; set; }
        public bool Silindi { get; set; }
        public List<HesapKartı> HesapKartıs { get; set; }
    }
}

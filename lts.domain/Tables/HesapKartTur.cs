using lts.domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.domain.Tables
{
    public class HesapKartTur: ITablo
    {
        [Key]
        public int TurID { get; set; }
        public string TurAdi { get; set; }
        public bool Silindi { get; set; }
        public List<HesapKartı> HesapKartıs { get; set; }
    }
}

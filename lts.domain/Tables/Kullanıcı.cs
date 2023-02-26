using lts.domain.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.domain.Tables
{
    public class Kullanıcı: ITablo
    {
        [Key]
        public int UserID { get; set; }
        public string Ad { get; set; }
        public string SoyAd { get; set; }
        public string KullanıcıAdi { get; set; }
        public int Sifre { get; set; }
        public string Email { get; set; }
        public int TelefonNo { get; set; }
        public bool Silindi { get; set; }
        

    }
}

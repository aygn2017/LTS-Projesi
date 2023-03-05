using lts.DTOS.Concrete;
using System.Collections.Generic;

namespace LTS.WEBUI.Models
{
    public class KullaniciRolViewModel
    {
        public List<HesapRol> Roller { get; set; }
        public List<HesapUser> Kullanicilar { get; set; }
    }
}

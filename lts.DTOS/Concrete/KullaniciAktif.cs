using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DTOS.Concrete
{
    public class KullaniciAktif
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string RPassword { get; set; }
        public string ResetCode { get; set; }
        public string EmailCode { get; set; }
    }
}

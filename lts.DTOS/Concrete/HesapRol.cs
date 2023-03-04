using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DTOS.Concrete
{
    public class HesapRol : IdentityRole<string>
    {
        public DateTime OlusturulmaTarihi { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace lts.DTOS.Concrete
{
    public class HesapUser : IdentityUser<string>
    {
        public string Tc { get; set; }
        public string GeciciSifre { get; set; }
    }
}
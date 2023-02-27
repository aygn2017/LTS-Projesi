using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.domain.Tables
{
    public class KullaniciRol
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int RolId { get; set; }
    }
}

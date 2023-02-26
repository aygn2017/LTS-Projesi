using lts.domain.Tables;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.DAL.Mapping
{
    public class HesapAltGrupMap : IEntityTypeConfiguration<HesapAltGrup>
    {
        public void Configure(EntityTypeBuilder<HesapAltGrup> builder)
        {
          



            builder.Property(x => x.AltGrupID);
            builder.Property(x => x.AltGrupID).UseIdentityColumn();
            builder.Property(x => x.GrupAdi).IsRequired();
            builder.Property(x => x.KartGrupID).IsRequired();
            builder.Property(x => x.Silindi).IsRequired();
            builder.Property(x => x.Silindi).HasDefaultValueSql("0");

            builder.HasMany(x => x.HesapKartıs).WithOne(x => x.HesapAltGrup).HasForeignKey(x => x.AltGrupID);
        }
    }
}

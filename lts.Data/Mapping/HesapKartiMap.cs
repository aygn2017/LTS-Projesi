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
    public class HesapKartiMap : IEntityTypeConfiguration<HesapKartı>
    {
        public void Configure(EntityTypeBuilder<HesapKartı> builder)
        {

       
            builder.HasKey(x => x.KartID);
            builder.Property(x => x.KartID).UseIdentityColumn();
            builder.Property(x => x.Unvan).IsRequired();
            builder.Property(x => x.VergiDairesi).IsRequired();
            builder.Property(x => x.TCNO).IsRequired();
            builder.Property(x => x.Adres).IsRequired();
            builder.Property(x => x.Silindi).IsRequired();
            builder.Property(x => x.Silindi).HasDefaultValueSql("0");

            builder.Property(x => x.TipID).IsRequired();
            builder.Property(x => x.TurID).IsRequired();
            builder.Property(x => x.KartGrupID).IsRequired();
            builder.Property(x => x.AltGrupID).IsRequired();
         





        }
    }
}

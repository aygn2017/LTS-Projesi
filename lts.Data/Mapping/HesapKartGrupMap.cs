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
    public class HesapKartGrupMap : IEntityTypeConfiguration<HesapKartGrup>
    {

        public void Configure(EntityTypeBuilder<HesapKartGrup> builder)
        {



            builder.HasKey(x => x.KartGrupID);
            builder.Property(x => x.KartGrupID).UseIdentityColumn();
            builder.Property(x => x.GrupAdi).IsRequired();
            builder.Property(x => x.Silindi).IsRequired();
            builder.Property(x => x.Silindi).HasDefaultValueSql("0");
            builder.HasMany(x => x.HesapKartıs).WithOne(x => x.HesapKartGrup).HasForeignKey(x => x.KartGrupID);
        }
    }
}
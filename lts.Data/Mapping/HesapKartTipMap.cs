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
    public class HesapKartTipMap : IEntityTypeConfiguration<HesapKartTip>
    {
        public void Configure(EntityTypeBuilder<HesapKartTip> builder)
        {

            builder.HasKey(x => x.TipID);
            builder.Property(x => x.TipID).UseIdentityColumn();
            builder.Property(x => x.TipAdi).IsRequired();
            builder.Property(x => x.Silindi).IsRequired();
            builder.Property(x => x.Silindi).HasDefaultValueSql("0");
            builder.HasMany(x => x.HesapKartıs).WithOne(x => x.HesapKartTip).HasForeignKey(x => x.TipID);
        }
    }
}

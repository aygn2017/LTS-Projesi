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
    public class HesapKartTurMap : IEntityTypeConfiguration<HesapKartTur>
    {
        public void Configure(EntityTypeBuilder<HesapKartTur> builder)
        {
            builder.HasKey(x => x.TurID);
            builder.Property(x => x.TurID).UseIdentityColumn();
            builder.Property(x => x.TurAdi).IsRequired();
            builder.Property(x => x.Silindi).IsRequired();
            builder.Property(x => x.Silindi).HasDefaultValueSql("0");
            builder.HasMany(x => x.HesapKartıs).WithOne(x => x.HesapKartTur).HasForeignKey(x => x.TurID);
        }
    }
}

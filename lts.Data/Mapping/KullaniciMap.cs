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
    public class KullaniciMap : IEntityTypeConfiguration<Kullanıcı>
    {
        public void Configure(EntityTypeBuilder<Kullanıcı> builder)
        {

            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserID).UseIdentityColumn();
            builder.Property(x => x.Ad).IsRequired();
            builder.Property(x => x.SoyAd).IsRequired();
            builder.Property(x => x.KullanıcıAdi).IsRequired();
            builder.Property(x => x.Sifre).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.TelefonNo).IsRequired();
            builder.Property(x => x.Silindi).IsRequired();
            builder.Property(x => x.Silindi).HasDefaultValueSql("0");

        }
    }
}

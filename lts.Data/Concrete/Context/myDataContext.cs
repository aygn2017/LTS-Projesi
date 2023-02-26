using lts.DAL.Mapping;
using lts.domain.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using lts.DTOS.Concrete;
using Microsoft.Extensions.Configuration;

namespace lts.Data.Concrete.Context
{
    public class myDataContext : IdentityDbContext<HesapUser>
    {
        public myDataContext()
        {

        }
        public myDataContext(DbContextOptions<myDataContext> options) : base(options)

        {
        }
        public DbSet<HesapAltGrup> HesapAltGrups { get; set; }
        public DbSet<HesapKartGrup> HesapKartGrups { get; set; }

        public DbSet<HesapKartı> HesapKartıs { get; set; }

        public DbSet<HesapKartTip> HesapKartTips { get; set; }

        public DbSet<HesapKartTur> HesapKartTurs { get; set; }

        public DbSet<Kullanıcı> Kullanıcıs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf(@"\")) + @"\LTS.WEBUI\")
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("LTSIdentityDbContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HesapAltGrupMap());
            modelBuilder.ApplyConfiguration(new HesapKartGrupMap());
            modelBuilder.ApplyConfiguration(new HesapKartiMap());
            modelBuilder.ApplyConfiguration(new HesapKartTipMap());
            modelBuilder.ApplyConfiguration(new HesapKartTurMap());
            modelBuilder.ApplyConfiguration(new KullaniciMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
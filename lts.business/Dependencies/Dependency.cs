using lts.business.Abtsract;
using lts.business.Concrete;
using lts.DAL.Concrete;
using lts.Data.Abstract;
using lts.Data.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lts.business.Dependencies
{
    public static class Dependency
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            #region Dal Katmanı
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IHesapAltGrupRepository, HesapAltGrupRepository>();
            services.AddScoped<IHesapKartGrupRepository, HesapKartGrupRepository>();
            services.AddScoped<IHesapKartRepository, HesapKartRepository>();
            services.AddScoped<IHesapKartTipRepository, HesapKartTipiRepository>();
            services.AddScoped<IHesapKartTurRepository, HesapKartTurRepository>();
            services.AddScoped<IKullaniciRepository, KullaniciRepository>();
            #endregion

            #region Business Katmanı 
            services.AddScoped(typeof(IGenericManager<>), typeof(GenericManager<>));
            services.AddScoped<IHesapAltGrupManager, HesapAltGrupManager>();
            services.AddScoped<IHesapKartGrupManager, HesapKartGrupManager>();
            services.AddScoped<IHesapKartManager, HesapKartManager>();
            services.AddScoped<IHesapKartTipManager, HesapKartTipManager>();
            services.AddScoped<IHesapKartTurManager, HesapKartTurManager>();
            services.AddScoped<IKullaniciManager, Kullanicilarimanager>();
            #endregion
        }
    }
}
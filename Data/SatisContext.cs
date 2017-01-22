using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EntityFrameworkIslemler.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EntityFrameworkIslemler
{

    public class SatisContext : DbContext
    {
        public SatisContext() : base("myDB") { }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // olusturulan modeller de 's takısı eklenmemesı ıcın gerekli
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
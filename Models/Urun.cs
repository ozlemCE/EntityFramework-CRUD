using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkIslemler.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Kategori")]
        public int KategoriId { get; set; }
        [DisplayName("Ürün Adı")]
        public string Ad { get; set; }
        [DisplayName("Ürün Fiyatı")]
        public double Fiyat { get; set; }
        public int Stok { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
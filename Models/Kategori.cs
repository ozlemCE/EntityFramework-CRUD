using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntityFrameworkIslemler.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        public string Adi { get; set; }

        public virtual ICollection<Urun> Urunler { get; set; }
    }
}
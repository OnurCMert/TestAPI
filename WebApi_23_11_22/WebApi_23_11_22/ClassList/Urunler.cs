using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_23_11_22.ClassList
{
    public class Urunler
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Tedarikci { get; set; }
        public string Kategori { get; set; }
        public decimal? Fiyat { get; set; }
        public short? Stok { get; set; } 
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_23_11_22.ClassList;
using WebApi_23_11_22.Models;

namespace WebApi_23_11_22.Controllers
{
    public class ProductsController : ApiController
    {
        Entities db = new Entities();

        [HttpGet]
        public List<Urunler> List()
        {
            return db.Products.Select(x => new Urunler
            {
                Id = x.ProductID,
                Ad = x.ProductName,
                Fiyat = x.UnitPrice,
                Kategori = x.Categories.CategoryName,
                Stok = x.UnitsInStock,
                Tedarikci = x.Suppliers.CompanyName
            }).ToList();

        }

        [HttpPost]
        public IHttpActionResult Ekle(Products urun)
        {
            db.Products.Add(urun);
            try
            {
                db.SaveChanges();
                return Ok(new ResultMessage() { type = true, Message = "Ürün kayıt işlemi başarı ile gerçekleşmiştir." });
            }
            catch (Exception)
            {

                return Ok(new ResultMessage() { type = false, Message = "Ürün kayıt işlemi esnasında bir hata meydana geldi." });
            }
        }

        [HttpPost]
        public Urunler Detay(int id)
        {
            Urunler veri = null;

            var urun = db.Products.Find(id);

            if (urun != null)
            {
                veri = new Urunler();
                veri.Id = urun.ProductID;
                veri.Ad = urun.ProductName;
                veri.Fiyat = urun.UnitPrice;
                veri.Kategori = urun.CategoryID.ToString();
                veri.Stok = urun.UnitsInStock;
                veri.Tedarikci = urun.SupplierID.ToString();
            }
            return veri;
            
        }

    }
}

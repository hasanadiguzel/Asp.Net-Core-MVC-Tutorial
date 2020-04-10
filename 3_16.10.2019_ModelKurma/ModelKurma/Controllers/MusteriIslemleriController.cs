using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelKurma.Models;

namespace ModelKurma.Controllers
{
    public class MusteriIslemleriController : Controller
    {
        //Sanal veritabanı...
        List<Musteri> musteriler = new List<Musteri>()
        {
            new Musteri{ Id = 1345, Adi = "Ahmet", Soyadi = "Çokçalışır", Adresi ="TOKİ"},
            new Musteri{ Id = 1864, Adi = "Mehmet", Soyadi = "Hiçdurmaz", Adresi ="Kızılay"},
            new Musteri{ Id = 1234, Adi = "Hasan", Soyadi = "Hepkoşar", Adresi ="Mamak"},
            new Musteri{ Id = 1643, Adi = "Hüseyin", Soyadi = "Yorulmaz", Adresi ="Koşuyolu"},
            new Musteri{ Id = 1214, Adi = "Cengiz", Soyadi = "Demir", Adresi ="Eskişehir Yolu"}
        };

        public IActionResult Index() //listeleme...
        {
            return View(musteriler);
        }
    }
}
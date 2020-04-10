using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MerhabaDunya.Models;

namespace MerhabaDunya.Controllers
{
    public class MerhabaController : Controller
    {
        public string Index()
        {
            return "Merhaba Dünya";
        }

        public string Selam()
        {
            return "Selam";
        }

        public string Hosgeldiniz()
        {
            return "<b>Merhaba Kullanıcı</b>, Uygulamaya Hoşgeldiniz...";
        }

        public IActionResult Hosgeldiniz2()
        {
            string isim = "Ahmet";
            ViewBag.x = isim;
            return View();
        }

        public IActionResult Hosgeldiniz3()
        {
            List<string> x = new List<string>()
            {
                "Ayşe",
                "Nazlı",
                "Mehmet",
                "Hasan",
                "Fatma"
            };
            ViewBag.x = x;
            return View();
        }
    }
}

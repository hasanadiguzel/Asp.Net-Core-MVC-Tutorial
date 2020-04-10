using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_VirtualDb.Models;

namespace CRUD_VirtualDb.Controllers
{
    public class MusteriIslemleriController : Controller
    {
        static List<Musteri> musteriler = new List<Musteri>()
        {
            new Musteri{ Id = 1345, Adi = "Ahmet", Soyadi = "Çokçalışır", Adresi ="TOKİ"},
            new Musteri{ Id = 1864, Adi = "Mehmet", Soyadi = "Hiçdurmaz", Adresi ="Kızılay"},
            new Musteri{ Id = 1234, Adi = "Hasan", Soyadi = "Hepkoşar", Adresi ="Mamak"},
            new Musteri{ Id = 1643, Adi = "Hüseyin", Soyadi = "Yorulmaz", Adresi ="Koşuyolu"},
            new Musteri{ Id = 1214, Adi = "Cengiz", Soyadi = "Demir", Adresi ="Eskişehir Yolu"}
        };

        // GET: MusteriIslemleri
        public ActionResult Index()
        {
            return View(musteriler);
        }

        // GET: MusteriIslemleri/Details/5
        public ActionResult Details(int id)
        {
            return View(musteriler.Where(x => x.Id == id).SingleOrDefault());
        }

        [HttpGet]
        // GET: MusteriIslemleri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusteriIslemleri/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Musteri musteri)
        {
            try
            {
                // TODO: Add insert logic here
                musteriler.Add(musteri);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: MusteriIslemleri/Edit/5
        public ActionResult Edit(int id)
        {
            return View(musteriler.Where(x => x.Id == id).SingleOrDefault());
        }

        // POST: MusteriIslemleri/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Musteri musteri)
        {
            try
            {
                // TODO: Add update logic here
                var hafizadakiMusteri = musteriler.Where(x => x.Id == id).SingleOrDefault();
                hafizadakiMusteri.Adi = musteri.Adi;
                hafizadakiMusteri.Soyadi = musteri.Soyadi;
                hafizadakiMusteri.Adresi = musteri.Adresi;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(musteriler.Where(x => x.Id == id).SingleOrDefault());
            }
        }

        [HttpGet]
        // GET: MusteriIslemleri/Delete/5
        public ActionResult Delete(int id)
        {
            return View(musteriler.Where(x => x.Id == id).SingleOrDefault());
        }

        // POST: MusteriIslemleri/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Musteri musteri)
        {
            try
            {
                // TODO: Add delete logic here
                musteri = musteriler.Where(x => x.Id == id).SingleOrDefault();
                musteriler.Remove(musteri);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(musteriler.Where(x => x.Id == id).SingleOrDefault());
            }
        }
    }
}
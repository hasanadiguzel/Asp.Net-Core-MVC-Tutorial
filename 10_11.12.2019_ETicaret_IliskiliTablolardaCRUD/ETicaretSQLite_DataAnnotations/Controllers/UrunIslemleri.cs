                                                                                                                                                                                                                using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ETicaret.Data;
using ETicaret.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ETicaret.Controllers
{
    public class UrunIslemleri : Controller
    {
        private readonly ETicaretContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        //dependency inection --> bağımlı enjeksiyon IHostingEnvironment eski versionda
        public UrunIslemleri(ETicaretContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: UrunIslemleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Urunler.Include(x => x.Resimler).ToListAsync());
        }

        // GET: UrunIslemleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //include : join vs sorguları çalıştırır....
            var urun = await _context.Urunler.Include(x => x.Resimler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // GET: UrunIslemleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UrunIslemleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Aciklama,Fiyat,Dosyalar")] Urun urun)
        {
            if (ModelState.IsValid)
            {
                var dosyaYolu = Path.Combine(_hostEnvironment.WebRootPath, "resimler");
                if(!Directory.Exists(dosyaYolu))
                {
                    Directory.CreateDirectory(dosyaYolu);
                }
                foreach (var item in urun.Dosyalar)
                {
                    if(item.ContentType.Substring(0, 5) == "image")
                    {

                        //memory stream herkes 100 dosya yüklese bellek şişer ve file stream
                        //create ile dosya varsa üzerine yazar ama createNew ile hata fırlatır
                        using(var dosyaAkisi = new FileStream(Path.Combine(dosyaYolu, item.FileName), FileMode.Create))
                        {
							//program çalışma zamanında iken ilgili dosyayı arka planda sunucuya kopyalar...
                            await item.CopyToAsync(dosyaAkisi);
                        }
                        

                        urun.Resimler.Add(new Resim {DosyaAdi = item.FileName });
                    }
                }
                
                _context.Add(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(urun);
        }

        // GET: UrunIslemleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //FindAsync(id) include ile çalışmıyor
            var urun = await _context.Urunler.Include(x => x.Resimler).SingleOrDefaultAsync(x => x.Id == id);
            if (urun == null)
            {
                return NotFound();
            }
            return View(urun);
        }

        // POST: UrunIslemleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Aciklama,Fiyat")] Urun urun)
        {
            if (id != urun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunExists(urun.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(urun);
        }

        // GET: UrunIslemleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urun = await _context.Urunler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        // POST: UrunIslemleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urun = await _context.Urunler.FindAsync(id);
            try
            {
                _context.Urunler.Remove(urun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                
                throw;
            }
            return RedirectToAction(nameof(Delete));
        }

        public async Task<IActionResult> ResimSil(int id)
        {
            var resim = await _context.Resimler.FindAsync(id);
            _context.Resimler.Remove(resim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Edit), new { id = resim.UrunuId} );
        }

        private bool UrunExists(int id)
        {
            return _context.Urunler.Any(e => e.Id == id);
        }
    }
}

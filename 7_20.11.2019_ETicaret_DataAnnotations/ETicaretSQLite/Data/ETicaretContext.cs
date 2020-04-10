using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaret.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Data {
    public class ETicaretContext : DbContext {
        public ETicaretContext (DbContextOptions<ETicaretContext> options)
         : base (options) 
        {

        }

        public DbSet<ETicaret.Models.Urun> Urunler { get; set; }
    }
}
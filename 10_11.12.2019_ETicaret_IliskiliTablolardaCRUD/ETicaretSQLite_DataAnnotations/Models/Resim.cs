using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ETicaret.Models
{
    public class Resim
    {
        public int Id { get; set; }
        public string DosyaAdi { get; set; }
        
        //skaler alan
        /*[ForeignKey] //farklı isim için
        public int UrunId { get; set; }*/
        public int UrunuId { get; set; }
        [Required] // zorunlu migration delete action cascade
        public Urun Urunu { get; set; } //.fk
    }
}

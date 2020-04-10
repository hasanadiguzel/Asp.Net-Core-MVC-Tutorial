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

        public Urun Urunu { get; set; } //.fk
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ETicaret.Models
{
    public class Urun
    {

        //kestrel sunuucusu

        public Urun()
        {
            Resimler = new List<Resim>(); 
        }

        [Key]
        public int Id { get; set; }

        [Display(Name="Adı")]
        [Required(ErrorMessage="{0} alanı gereklidir")]
        public string Ad { get; set; }

        [Display(Name="Açıklama")]
        [Required(ErrorMessage="{0} alanı gereklidir")]
        public string Aciklama { get; set; }

        [Display(Name="Fiyatı")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:c}")]
        [Required(ErrorMessage="{0} alanı gereklidir")]
        public decimal Fiyat { get; set; }

        //public string Resim { get; set; }

        [NotMapped] //veritabanına yansımamasını sağlar
        public IFormFile[] Dosyalar { get; set; }

        public List<Resim> Resimler { get; set; }
    }
}

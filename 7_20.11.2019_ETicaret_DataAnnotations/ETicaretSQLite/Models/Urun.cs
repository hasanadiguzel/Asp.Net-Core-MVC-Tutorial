using System;
using System.ComponentModel.DataAnnotations;

namespace ETicaret.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Adı")]
        [Required(ErrorMessage="{0} alanı gereklidir.")]
        public string Ad { get; set; }

        [Display(Name="Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name="Fiyatı")]
        [Required(ErrorMessage="{0} alanı gereklidir.")]
        [DisplayFormat(ApplyFormatInEditMode=false, DataFormatString="{0:c}")]
        public decimal? Fiyat { get; set; }
    }
}
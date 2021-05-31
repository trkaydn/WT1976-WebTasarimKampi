using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MuseumProject.Models.Entities
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
        public int CategoryId { get; set; }

        [StringLength(50), Required(ErrorMessage = "Koleksiyon ismi zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        public string Description { get; set; }

        [StringLength(250), Required(ErrorMessage = "Fotoğraf Url alanı zorunludur.")]
        public string Photo { get; set; }

        public DateTime AddDate { get; set; }


    }
}
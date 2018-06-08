using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Samochody.Validators;

namespace Samochody.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [DateRange("01/01/2000")]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Komentarz")]
        public string Comment { get; set; }

        [Required]
        [Display(Name ="Samochód")]
        public int CarID { get; set; }

        public virtual Car Car { get; set; }
    }
}
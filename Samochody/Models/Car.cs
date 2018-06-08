using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Samochody.Validators;

namespace Samochody.Models
{
    [SoldLaterThanBought(ErrorMessage = "Data sprzedaży musi być większa od daty kupna")]
    [BoughtEarlierThanSold(ErrorMessage = "Data kupna musi być mniejsza od daty sprzedaży")]
    [SoldEarlierThanCurrentDate(ErrorMessage = "Data sprzedaży nie może być z przyszłości ;)")]
    public class Car
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Marka")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Required]
        [DateRange("01/01/2000")]
        [DataType(DataType.Date)]
        [Display(Name = "Kupiony")]
        public DateTime Bought { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Sprzedany")]
        public DateTime Sold { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
    public class CarDBCtxt : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
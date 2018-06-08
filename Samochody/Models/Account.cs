using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Samochody.Models
{
    public class Account
    {
        [Display(Name = "Nazwa użytkownika")]
        public string Username
        {
            get; set;
        }

        [Display(Name = "Hasło")]
        public string Password
        {
            get; set;
        }

        public string[] Roles
        {
            get; set;
        }

    }
}
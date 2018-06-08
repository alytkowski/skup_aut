using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samochody.Models
{
    public class AccountModel
    {
        private List<Account> listAccounts = new List<Account>();

        public AccountModel()
        {
            listAccounts.Add(new Account
            {
                Username = "admin",
                Password = "admin",
                Roles = new string[] { "admin", "regular" }
            });

            listAccounts.Add(new Account
            {
                Username = "user",
                Password = "user",
                Roles = new string[] { "regular" }
            });
        }

        public Account find(string username)
        {
            return listAccounts.Where(acc => acc.Username.Equals(username)).FirstOrDefault();
        }

        public Account login(string username, string password)
        {
            return listAccounts.Where(acc => acc.Username.Equals(username) &&
            acc.Password.Equals(password)).FirstOrDefault();
        }
    }
}
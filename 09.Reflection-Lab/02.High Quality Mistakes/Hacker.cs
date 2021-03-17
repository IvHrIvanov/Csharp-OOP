using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";
        private string Password
        {
            get => this.password;
            set => this.password = value;
        }
        public int Id { get; set; }

        public void DownloadAllBankAccountsInTheWorld()
        {
        }

    }
}

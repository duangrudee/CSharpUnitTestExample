using System;
using System.Linq;
using MyApp.Interfaces;

namespace MyApp
{
    public class AccountDb : IAccountDb
    {
        private AccountInfo[] _bankAccountList = new AccountInfo[] 
        {
            new AccountInfo 
            {
                Name = "Peter Smith",
                AccountNumber = "01234567890",
                AccountType = "Savings"
            },
            new AccountInfo 
            {
                Name = "Mark Zuckerburg",
                AccountNumber = "01234567891",
                AccountType = "Fixed deposite"
            },
            new AccountInfo 
            {
                Name = "Sadio Mane",
                AccountNumber = "01234567892",
                AccountType = "Salary"
            }
        };

        public AccountInfo FindAccountInfo(string bankAccountNo)
        {
            return _bankAccountList.FirstOrDefault(b => b.AccountNumber == bankAccountNo);
        }

    }
}
using System;
using System.Linq;

namespace MyApp
{
    public class BankBalanceDb
    {
        private AccountBalance[] _bankBalance = new AccountBalance[]
        {
            new AccountBalance { AccountNumber = "01234567890", DepoisteAmount = 1000, DepoisteDate = new DateTime(2005, 03, 31)},
            new AccountBalance { AccountNumber = "01234567891", DepoisteAmount = 2000, DepoisteDate = new DateTime(2005, 03, 31)},
            new AccountBalance { AccountNumber = "01234567892", DepoisteAmount = 3000, DepoisteDate = new DateTime(2005, 03, 31)},

            new AccountBalance { AccountNumber = "01234567890", DepoisteAmount = 4000, DepoisteDate = new DateTime(2006, 03, 31)},
            new AccountBalance { AccountNumber = "01234567891", DepoisteAmount = 5000, DepoisteDate = new DateTime(2006, 03, 31)},
            new AccountBalance { AccountNumber = "01234567892", DepoisteAmount = 6000, DepoisteDate = new DateTime(2006, 03, 31)}
        };
        
       public AccountBalance[] GetAccountBalance(string accountNumber)
       {
           return _bankBalance.Where(b => b.AccountNumber == accountNumber).ToArray();
       }
    }
}

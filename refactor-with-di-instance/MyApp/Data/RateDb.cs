using System;
using System.Linq;

namespace MyApp
{
    public class RateDb
    {
        private InterestRate[] _rates = new InterestRate[]
        {
            new InterestRate { AccountType = "Savings", AnnualRate = 0.01 },
            new InterestRate { AccountType = "Fixed Deposite", AnnualRate = 0.02 },
            new InterestRate { AccountType = "Salary", AnnualRate = 0 }          
        };
        
       public double? GetAnnualRate(string type)
       {
           return _rates.FirstOrDefault(b => b.AccountType == type)?.AnnualRate;
       }
    }
}

using System;

namespace MyApp 
{
    public class InterestCalculator 
    {
        public double CalculateBankInterest (string accountNumber) 
        {
            // Read account number
            var accountInfo = new AccountDb().FindAccountInfo (accountNumber);

            // Read all deposite amount and Date
            var balance = new BankBalanceDb().GetAccountBalance (accountInfo.AccountNumber);

            // Read Interest Rate
            var rate = new RateDb().GetAnnualRate (accountInfo.AccountType);

            // total interest
            return Calculate (balance, DateTime.Now, rate.Value);

        }

        private double Calculate (AccountBalance[] balanceList, DateTime todayDate, double rate) 
        {
            double interestAmount  =0;
            foreach(var deposite in balanceList)
            {
                var numberOfDays = todayDate.Subtract(deposite.DepoisteDate).Days;
                interestAmount += deposite.DepoisteAmount * (numberOfDays / 365);
            }
            return interestAmount;
        }

    }
}
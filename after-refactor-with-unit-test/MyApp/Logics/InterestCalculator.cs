using System;
using MyApp.Interfaces;

namespace MyApp 
{
    public class InterestCalculator 
    {
        private readonly IAccountDb _accountDb;
        private readonly IBankBalanceDb _bankBalanceDb;
        private readonly IRateDb _rateDb;

        public InterestCalculator(IAccountDb accountDb, IBankBalanceDb bankBalanceDb, IRateDb rateDb)
        {
            _accountDb = accountDb;
            _bankBalanceDb = bankBalanceDb;
            _rateDb = rateDb;
        }

        public double CalculateBankInterest (string accountNumber) 
        {
            // Read account number
            var accountInfo = _accountDb.FindAccountInfo (accountNumber);

            // Read all deposite amount and Date
            var balance = _bankBalanceDb.GetAccountBalance(accountInfo.AccountNumber);

            // Read Interest Rate
            var rate = _rateDb.GetAnnualRate (accountInfo.AccountType);

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
using System;

namespace MyApp 
{
    class Program 
    {
        private const string usageText = "Usage: InterestCalculator [Bank account number]";

        static void Main (string[] args) 
        {
            if (args.Length < 1) 
            {
                Console.WriteLine (usageText);
                return; 
            }

            Console.WriteLine($"Calculating interest amount for account number {args[0]} ...");
            
            var result = new 
                InterestCalculator(new AccountDb(), new BankBalanceDb(), new RateDb())
                .CalculateBankInterest (args[0], DateTime.Now);
                
            Console.WriteLine ($"Your annual interest rate as of today = {result}");
        }
    }
}
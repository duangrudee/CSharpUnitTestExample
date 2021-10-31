using System;
using Xunit;
using MyApp.Interfaces;
using NSubstitute;
using FluentAssertions;

namespace MyApp.UnitTest
{
    public class InterestCalculatorTest
    {
        [Fact]
        public void CalculatInterest_Happy_Test()
        {

            // Arrange - create mock object and mock input data            
            var mockAccountDb = Substitute.For<IAccountDb>();            
            mockAccountDb.FindAccountInfo(Arg.Any<string>()).Returns(new AccountInfo { Name = "Test account name", AccountNumber = "111", AccountType = "anytype"});

            var mockBankBalance = Substitute.For<IBankBalanceDb>();
            mockBankBalance.GetAccountBalance(Arg.Any<string>())
                .Returns(new AccountBalance[] { new AccountBalance { AccountNumber = "111" , DepoisteAmount = 100, DepoisteDate = DateTime.Now.AddDays(-365) } });

            var mockRateDb = Substitute.For<IRateDb>();
            mockRateDb.GetAnnualRate(Arg.Any<string>()).Returns(0.05); // give 5% for whatever account types
            

            // Act
            var interestCalc = new InterestCalculator(mockAccountDb, mockBankBalance, mockRateDb);
            var interestRate = interestCalc.CalculateBankInterest("111");

            // Assert
            interestRate.Should().BeGreaterThan(0);
            interestRate.Should().BeGreaterThan(5);
        }
    }
}

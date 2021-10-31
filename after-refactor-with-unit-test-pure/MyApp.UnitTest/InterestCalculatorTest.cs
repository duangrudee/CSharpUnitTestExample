using System;
using Xunit;
using MyApp.Interfaces;
using NSubstitute;
using FluentAssertions;

namespace MyApp.UnitTest
{
    public class InterestCalculatorTest
    {
        [Theory]        
        [InlineData(100, 0.05, "2020-12-31", 5)]
        [InlineData(100, 0.02, "2020-12-31", 2)]
        [InlineData(100, 0.05, "2021-10-31", 9.16)]
        [InlineData(100, 0.02, "2021-10-31", 3.67)]
        public void CalculatInterest_Happy_Test(double depositeAmount, double rate, string currentDate, double expectedRate)
        {

            // Arrange - create mock object and mock input data            
            var mockAccountDb = Substitute.For<IAccountDb>();            
            mockAccountDb.FindAccountInfo(Arg.Any<string>()).Returns(new AccountInfo { Name = "Test account name", AccountNumber = "111", AccountType = "anytype"});

            var mockBankBalance = Substitute.For<IBankBalanceDb>();
            mockBankBalance.GetAccountBalance(Arg.Any<string>())
                .Returns(new AccountBalance[] { new AccountBalance { AccountNumber = "111" , DepoisteAmount = depositeAmount, DepoisteDate = new DateTime(2020,1,1) } });

            var mockRateDb = Substitute.For<IRateDb>();
            mockRateDb.GetAnnualRate(Arg.Any<string>()).Returns(rate);             

            // Act
            var interestCalc = new InterestCalculator(mockAccountDb, mockBankBalance, mockRateDb);
            var interestRate = interestCalc.CalculateBankInterest("111", DateTime.ParseExact(currentDate, "yyyy-MM-dd", null));

            // Assert
            interestRate.Should().Be(expectedRate);
        }
    }
}

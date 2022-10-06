using System;
using MockATM;
using Xunit;

namespace BankATMTestsLibrary;

public class UnitTest1
{
    [Fact]
    public void ViewBalance_ShouldReturnAccountBalance()
    {
        decimal expected = 25.5m;
        decimal actual = MockATM.Program.ViewBalance();

        Assert.Equal(expected, actual);
    }

    // [Fact]
    [Theory]
    // [InlineData(3.50, 22.0)] // this fails
    [InlineData(7, 18.5)]
    // [InlineData(25, .5)] // this fails
    [InlineData(27, 25.5)]
    public void Withdraw_ShouldReturnBalanceAfterWithdraw(decimal withdrawAmount, decimal expected)
    {
        decimal actual = MockATM.Program.Withdraw(withdrawAmount);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(5, 30.5)] // failed
    [InlineData(5.25, 30.75)] // failed
    [InlineData(0, 25.5)] // failed
    public void Deposit_ShouldReturnBalanceAfterDeposit(decimal depositAmount, decimal expected)
    {
        decimal actual = MockATM.Program.Deposit(depositAmount);

        Assert.Equal(expected, actual);
    }
}
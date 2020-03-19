using System;
using Xunit;
using Lab02_Unit_Tests;

namespace Lab02_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanWithdraw()
        {
            decimal balance = 100;
            decimal amount = 10;
            decimal result = Program.Withdraw(balance, amount);
            Assert.Equal(90, result);
        }

        [Fact]
        public void CantWithdraw()
        {
            decimal balance = 100;
            decimal amount = 1000;
            decimal result = Program.Withdraw(balance, amount);
            Assert.Equal(0, result);
        }

        [Fact]
        public void CanDeposit()
        {
            decimal balance = 100;
            decimal amount = 10;
            decimal result = Program.Deposit(balance, amount);
            Assert.Equal(110, result);
        }
    }
}

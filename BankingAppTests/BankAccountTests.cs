using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Tests
{
	[TestClass()]
	public class BankAccountTests
	{
		
		BankAccount myAcc;
		[TestInitialize]   
		public void UnitTests()
		{
			myAcc = new BankAccount(1000);
		}
		//1
		[TestMethod()]
		[TestCategory("Deposite")]
		public void Deposit_PositiveAmount_ShouldAddToExistingBalance()
		{
			//ARRANGE - Create variables and objects
			//for test
			BankAccount bank = new BankAccount();
			double startBalance = 0;
			double depositAmount = 10.5;
			double expectedBalance = startBalance +
											depositAmount;

			//ACT - Run method under test
			bank.Deposit(depositAmount);

			//ASSERT - Check if test passes or fails
			Assert.AreEqual(expectedBalance, bank.Balance);
		}
		//2
		[TestMethod]
		[TestCategory("Deposite")]
		public void Deposit_PositiveAmount_ReturnsNewBalance()
		{
			//Arrange
			BankAccount acc = new BankAccount();
			double depositAmt = 5.5;
			double expectedReturn = 5.5;

			//Act
			double actualReturn =
					acc.Deposit(depositAmt);

			//Assert
			Assert.AreEqual(expectedReturn,
									actualReturn);
		}
		//3
		[TestMethod]
		[TestCategory("Deposite")]
		//[ExpectedException(typeof(ArgumentException))]
		[DataRow(-.01)]
		[DataRow(-1000)]
		[DataRow(-.0000001)]
		[DataRow(double.MinValue)]
		public void Deposit_NegativeAmount_ShouldThrowException(double invalidDeposit)
		{
			//Arrange
			BankAccount bank = new BankAccount();
			//double invalidDeposit = -0.01;

			//Act
			//Assert handled by [ExpectedException]
			//bank.Deposit(invalidDeposit);

			//Act => Assert
			Assert.ThrowsException<ArgumentException>
				(() => bank.Deposit(invalidDeposit));
		}
		//4
		[TestMethod]
		[TestCategory("Withdraw")]
		public void Withdrawl_PositiveAmount_ShouldSubtractFromBalance()
		{
			//Arrange       // set up all the variables needed for the test.
			BankAccount acc = GetAccount();
			double initialBalance = 100;
			double withdrawAmt = 50;
			double expectedBalance = 50;
			acc.Deposit(initialBalance);

			//Act       // use the method you are testing
			acc.Withdraw(withdrawAmt);

			//Assert   // Check your results 
			Assert.AreEqual(expectedBalance, acc.Balance);
		}
		//5
		[TestMethod]
		[TestCategory("Withdraw")]
		public void Withdrawl_NegativeAmount_ShouldThrowException()
		{
			//Arrange
			BankAccount acc = GetAccount();
			double negativeWithdrawAmt = -5;

			//Act
			
			
			//Assert
			Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(negativeWithdrawAmt));
		}


		/// <summary>
		/// creates an empty bank Account
		/// </summary>
		/// <returns></returns>
		public BankAccount GetAccount()
		{
			BankAccount acc = new BankAccount();
			return acc;
		}
		//6
		[TestMethod]
		[TestCategory("Constructor")]
		public void Create_AccountWithBalance_ShouldHaveBalance()
		{
			//Arrange      //Act is in the same step when testing a constructor.
			double acc2Amt = 500;
			double acc3Amt = 100;
			BankAccount acc = new BankAccount();
			BankAccount acc2 = new BankAccount(acc2Amt);
			BankAccount acc3 = new BankAccount(acc3Amt, "123");

			//Assert
			Assert.AreEqual(0, acc.Balance);
			Assert.AreEqual(acc2Amt, acc2.Balance);
			Assert.AreEqual(acc3Amt, acc3.Balance);
		}

		//7
		[TestMethod]
		public void OverOneThousandDollars_UnderOneThousand_ShouldBeFalse()
		{
			//Arrange
			myAcc = new BankAccount(500);
			bool expectedResult = false;

			//Act
			bool results = myAcc.OverOneThousandDollars();

			//Assert
			Assert.AreEqual(expectedResult, results);

			
		}

		//8
		[TestMethod]
		public void OverOneThousandDollars_OverOneThousand_ShouldBeTrue()
		{
			//Arrange
			myAcc = new BankAccount(5000);
			bool ExpectedResults = true;


			//Act
			bool results = myAcc.OverOneThousandDollars();

			//Assert
			Assert.AreEqual(ExpectedResults, results);
		}

		//9.
		[TestMethod]
		public void Transfer_BankBalancesAreCorrect_Bank1ShouldHaveAmtLessBank2ShouldHaveAmtMore()
		{
			BankAccount bank1 = new BankAccount(1000);
			BankAccount bank2 = new BankAccount(500);
			double withdrawAmt = 500;
			double bank1ExpectedAmt = 500;
			double bank2ExpectedAmt = 1000;

			//Act
			bank1.Transfer(bank2, withdrawAmt);
			//Assert
			Assert.AreEqual(bank2.Balance, bank2ExpectedAmt);
			Assert.AreEqual(bank1.Balance, bank1ExpectedAmt);
		}

		//10.
		[TestMethod]
		public void Transfer_BankAccountPassedNotNull_ShouldThrowIllegalArgumentException()
		{
			//Arrange
			BankAccount b1 = new BankAccount(500);
			BankAccount b2 = null;
			double transferAmt = 500;
			//Act

			//Assert
			Assert.ThrowsException<ArgumentException>(() => b1.Transfer(b2, transferAmt));
		}

		//11. 
		[TestMethod]
		public void Withdraw_WithdrawMoreThanCurrentBalance_ShouldThrowIllegalArgumentException()
		{
			//Arrange
			double currentActBalance = 500;
			BankAccount b = new BankAccount(currentActBalance);
			double withdrawAmt = 1000;

			//Assert
			Assert.ThrowsException<ArgumentException>(() => b.Withdraw(withdrawAmt));
		}

		//12.
		[TestMethod]
		public void Create_WithBonus_ShouldCreateAccountWithTwoHundredBonus()
		{
			//Arrange
			double initialBalance = 2500;
			BankAccount b = new BankAccount(initialBalance);
			double expectedBalance = 2700;
			//Act

			//Assert
			Assert.AreEqual(expectedBalance, b.Balance);
		}
	}
}

//roy osherove the art of unit testing   //rescource for unit testing.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    public class BankAccount
    {
		// : after the perenthesis  lets you call another constructor
		// you do this to seperate your logic and make it all call one constructor in the end.
		public BankAccount() : this(0, null)
		{

		}

		public BankAccount(double initialBalance) : this(initialBalance, null)
		{
			
		}

		public BankAccount(double initialBalance, string accNum)
		{
			if(initialBalance >= 2000)
			{
				Balance = initialBalance + 200;
			}
			else
			{
				Balance = initialBalance;
			}

			
			AccountNumber = accNum;
			
		}

        public double Balance { get; private set; }

        public string AccountNumber { get; set; }

        public string AccountHolder { get; set; }

        /// <summary>
        /// Deposit amount and adds to balance
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Existing balance plus deposit amount</returns>
        public double Deposit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("You cannot deposit a negative amount");

            Balance += amount;
            return Balance;
        }

        public double Withdraw(double amount)
        {	
			if(amount < 0)
			{
				throw new ArgumentException("You cant withdraw a negative amount");
			}
			if(amount > Balance)
			{
				throw new ArgumentException("We will not let you overdraft");
			}
            Balance -= amount;
            return Balance;
        }

		public bool OverOneThousandDollars()
		{
			if(Balance > 1000)
			{
				return true;
			}
			return false;
		}

		public void Transfer(BankAccount b, double transferAmt)
		{
			if(b == null)
			{
				throw new ArgumentException("You cant transfer to a null bankAccount");
			}
			Withdraw(transferAmt);
			b.Deposit(transferAmt);	
		}

		
    }
}

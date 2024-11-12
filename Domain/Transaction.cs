using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    class Transaction
    {
        public BankAccount FromAccount;
        public BankAccount ToAccount;
        public DateTime Date;
        public decimal Amount;
        public Verification verification = null;

        public Transaction(BankAccount fromAccount, BankAccount toAccount, decimal amount)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Amount = amount;
            if (Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Amount), "actually muzes");
            }
            Date = DateTime.Now;
        }

        public void Execute()
        {
            FromAccount.Withdraw(Amount);
            ToAccount.Deposit(Amount);
        }

        public bool HumanVerificationNeeded()
        {
            return Amount > 100000;
        }
    }
}
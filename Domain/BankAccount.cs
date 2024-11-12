using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    class BankAccount
    {
        public int AccountNumber;
        private static int number = 1;
        private decimal balance;
        public string OwnerName;

        public BankAccount(decimal balance, string ownerName)
        {
            AccountNumber = number;
            number++;
            this.balance = balance;
            if(balance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(balance), "by bylo jak muj bankovni ucet");
            }
            OwnerName = ownerName;
            if(OwnerName.Equals("") || OwnerName == null)
            {
                throw new ArgumentOutOfRangeException(nameof(OwnerName), "nemas jmeno");
            } 
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if(balance < amount)
            {
                throw new InvalidOperationException(nameof(amount));
            }
            else
            {
                balance -= amount;
            }
            
        }

        public override string ToString()
        {
            return $"Account number: {AccountNumber}, Balance:{balance}, Owner name:{OwnerName}";
        }
    } 
}

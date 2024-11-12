using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    class Bank
    {
        public string BankName;
        List<BankAccount> BankAccounts;
        List<Transaction> Transactions;

        public Bank(string bankName)
        {
            BankName = bankName;
            BankAccounts = new List<BankAccount>();
            Transactions = new List<Transaction>();
        }

        public void AddAccount(BankAccount bankAccount)
        {
            BankAccounts.Add(bankAccount);
        }
        
        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void AllAcounts()
        {
            Console.WriteLine($"Všechny účty banky {BankName}: ");
            foreach(BankAccount banks in BankAccounts)
            {
                Console.WriteLine(banks);
            }
        }
        public void AllTransactions()
        {
            Console.WriteLine($"Všechny transakce banky {BankName}: ");
            foreach (Transaction transactions in Transactions)
            {
                Console.WriteLine($"Z účtu: {transactions.FromAccount.AccountNumber}, na účet: {transactions.ToAccount.AccountNumber}, odeslaná částka: {transactions.Amount}");
            }
        }

        public void VerifyLargeTransactions(string verifier)
        {
            Random rd = new Random();
            foreach (Transaction transactions in Transactions)
            {
                if (transactions.HumanVerificationNeeded() && transactions.verification == null)
                {
                    VerificationResult Vresult = (VerificationResult)rd.Next(0,4);
                    transactions.verification = new Verification(verifier, Vresult, "info");
                    Console.WriteLine($"Transakce s castkou {transactions.Amount} byla overena od {verifier} a jeji status je {Vresult}");
                }
            }
        }
        public void DeniedTransactions()
        {
            Console.WriteLine("- Zamítnuté transakce - ");
            foreach (var transaction in Transactions)
            {
                if (transaction.HumanVerificationNeeded() && transaction.verification != null && transaction.verification.verificationResult == VerificationResult.Denied)
                {
                    Console.WriteLine($"Číslo účtu ze kterého byly peníze odeslány: {transaction.FromAccount.AccountNumber} (Vlastník: {transaction.FromAccount.OwnerName})");
                    Console.WriteLine($"Číslo účtu na kteý byly peníze odeslány: {transaction.ToAccount.AccountNumber} (Vlastník: {transaction.ToAccount.OwnerName})");
                    Console.WriteLine($"Odesílaná částka: {transaction.Amount}");
                    Console.WriteLine($"Dodatečné informace:  {transaction.verification.FurtherInfo}");
                    Console.WriteLine($"Schváleno od: {transaction.verification.Verifier}");
                }
            }
        }
    }
}
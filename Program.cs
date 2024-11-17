using BankApp.Domain;
using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Bank banka = new Bank("banka");
                BankAccount ucet1 = new BankAccount(50000000000000, "uzivatel1");
                BankAccount ucet2 = new BankAccount(200, "uzivatel2");
                banka.AddAccount(ucet1);
                banka.AddAccount(ucet2);
                banka.AllAcounts();

                Transaction transakce1 = new Transaction(ucet1, ucet2, 5);
                Transaction transakce2 = new Transaction(ucet1, ucet2, 10);
                Transaction transakce3 = new Transaction(ucet1, ucet2, 500000000000);

                banka.AddTransaction(transakce1);
                banka.AddTransaction(transakce2);
                banka.AddTransaction(transakce3);

                transakce1.Execute();
                transakce2.Execute();
                transakce3.Execute();

                banka.AllTransactions();

                banka.VerifyLargeTransactions("verifikator");

                banka.DeniedTransactions();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            
            Console.ReadLine();
        }
    }
}

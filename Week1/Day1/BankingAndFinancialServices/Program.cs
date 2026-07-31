using System;

namespace BankingAndFinancialServices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Transaction[] transactions =
            {
                new Transaction { AccountId="A12", Amount=5000, Time="10:05", Merchant="Amazon" },
                 new Transaction { AccountId="A14", Amount=20000, Time="10:16", Merchant="Flipkart" },
                new Transaction { AccountId="A12", Amount=7000, Time="10:34", Merchant="Amazon" },
                new Transaction { AccountId="A11", Amount=1500, Time="11:04", Merchant="Swiggy" },
                new Transaction { AccountId="A11", Amount=30000, Time="11:38", Merchant="Amazon" },
                 new Transaction { AccountId="A12", Amount=16000, Time="09:20", Merchant="Flipkart" }

            };

            Console.WriteLine("Large Transactions");
            LargeTransactions(transactions);

            Console.WriteLine();

            Console.WriteLine("Repeated Account Transactions");
            RepeatedTransactions(transactions);
        }

        // Large amount check if amount is greater than 10000
        static void LargeTransactions(Transaction[] transactions)
        {
           for (int i = 0; i < transactions.Length; i++)
            {
             if (transactions[i].Amount > 10000)
                {
                    Console.WriteLine(
                        transactions[i].AccountId + "  " +
                        transactions[i].Amount + "  " +
                        transactions[i].Merchant);
                }
            }
        }

        // Same account repeated 
        static void RepeatedTransactions(Transaction[] transactions)
        {
            for (int i = 0; i < transactions.Length; i++)
            {
               for (int j = i + 1; j < transactions.Length; j++)
                {
                    if (transactions[i].AccountId == transactions[j].AccountId)
                    {
                        Console.WriteLine(transactions[i].AccountId + " has multiple transactions.");
                        break;
                    }
                }
            }
        }
    }
}
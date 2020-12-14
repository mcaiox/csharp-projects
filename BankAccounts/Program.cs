using System;


namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {

            var account = new BankAccount("Chin", 1000000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with £{account.Balance} initial balance.");
        }
    }
}

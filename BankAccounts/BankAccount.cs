using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank // Namespace allows you top logically organise your code.
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        //Private means it can only be accessed by code inside the BankAccount class.
        //Static meaning it is shared by all of the BankAccount objects.
        //The value of a non static variable is unique to each instance of the BA object.

        //The three below are properties. Properties are data elements and can have code that enforces validation or other rules.
        public string Number { get; }  //It has a 10-digit number that uniquely identifies the bank account.
        public string Owner { get; set; } //It has a string that stores the name or names of the owners.
        //This creates a private field called Owner, and two methods getOwner and setOwner.
        public decimal Balance
        {
            get //getter becomes a function of some sort
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
            set{}
        } //The balance can be retrieved. //The initial balance must be positive.

        //It accepts deposits.
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }


        //Withdrawals cannot result in a negative balance.
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        private List<Transaction> allTransactions = new List<Transaction>();

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

    } 
}

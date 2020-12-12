using System;
using System.Collections.Generic;
namespace classes // Namespace allows you top logically organise your code.
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        //Private means it can only be accessed by code inside the BA class.
        //Static meaning it is shared by all of the BankAccount objects.
        //The value of a non static variable is unique to each instance of the BA object.

        //The three below are properties. Properties are data elements and can have code that enforces validation or other rules.
        public string Number { get; }  //It has a 10-digit number that uniquely identifies the bank account.
        public string Owner { get; set; } //It has a string that stores the name or names of the owners.
        //This creates a private field called Owner, and two methods getOwner and setOwner.
        public decimal Balance
        {
            get
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

        }

        
        //Withdrawals cannot result in a negative balance.
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {

        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Balance = initialBalance;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
                
        }
        private List<Transaction> allTransactions = new List<Transaction>();

    }
}

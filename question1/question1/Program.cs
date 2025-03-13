using System;

namespace BankAccountApp
{
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Transfer(decimal amount);
        void DisplayBalance();
    }

    public abstract class BankAccount : IBankAccount
    {
        protected decimal balance;
        public const decimal ExchangeRate = 25000; // 1 USD = 25,000 VND

        public abstract void Deposit(decimal amount);
        public abstract void Transfer(decimal amount);
        public abstract void DisplayBalance();
    }

    public class NormalAccount : BankAccount
    {
        public override void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount:N0} VND. Your balance: {balance:N0} VND");
        }

        public override void Transfer(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"You transferred {amount:N0} VND. Your balance: {balance:N0} VND");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public override void DisplayBalance()
        {
            Console.WriteLine($"Balance: {balance:N0} VND");
        }
    }

    public class ExchangeAccount : BankAccount
    {
        public override void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount:N2} USD. Your balance: {balance:N2} USD");
        }

        public override void Transfer(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                decimal vndAmount = amount * ExchangeRate;
                Console.WriteLine($"You transferred {vndAmount:N0} VND. Your balance: {balance * ExchangeRate:N0} VND");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public override void DisplayBalance()
        {
            Console.WriteLine($"Balance: {balance * ExchangeRate:N0} VND");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBankAccount normalAccount = new NormalAccount();
            IBankAccount exchangeAccount = new ExchangeAccount();

            while (true)
            {
                Console.WriteLine("\nBank Account Menu:");
                Console.WriteLine("1. Deposit to Normal Account");
                Console.WriteLine("2. Deposit to Exchange Account");
                Console.WriteLine("3. Transfer from Normal Account");
                Console.WriteLine("4. Transfer from Exchange Account");
                Console.WriteLine("5. Check Normal Account Balance");
                Console.WriteLine("6. Check Exchange Account Balance");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter amount (VND): ");
                        decimal vndDeposit = decimal.Parse(Console.ReadLine());
                        normalAccount.Deposit(vndDeposit);
                        break;
                    case "2":
                        Console.Write("Enter amount (USD): ");
                        decimal usdDeposit = decimal.Parse(Console.ReadLine());
                        exchangeAccount.Deposit(usdDeposit);
                        break;
                    case "3":
                        normalAccount.DisplayBalance();
                        Console.Write("Enter amount (VND): ");
                        decimal vndTransfer = decimal.Parse(Console.ReadLine());
                        normalAccount.Transfer(vndTransfer);
                        break;
                    case "4":
                        exchangeAccount.DisplayBalance();
                        Console.Write("Enter amount (USD): ");
                        decimal usdTransfer = decimal.Parse(Console.ReadLine());
                        exchangeAccount.Transfer(usdTransfer);
                        break;
                    case "5":
                        normalAccount.DisplayBalance();
                        break;
                    case "6":
                        exchangeAccount.DisplayBalance();
                        break;
                    case "0":
                        Console.WriteLine("Thank you! Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}

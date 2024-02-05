using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class BankAccount
{
    public string AccountHolder { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountHolder, decimal initialBalance)
    {
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Deposit successful. New balance: {Balance:C}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be greater than zero.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds for withdrawal.");
            return;
        }

        Balance -= amount;
        Console.WriteLine($"Withdrawal successful. New balance: {Balance:C}");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Current Balance: {Balance:C}");
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = null;

        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Access Account");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter account holder's name: ");
                    string accountHolder = Console.ReadLine();
                    Console.Write("Enter initial deposit amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
                    {
                        account = new BankAccount(accountHolder, initialDeposit);
                        Console.WriteLine("Account created successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for initial deposit.");
                    }
                    break;

                case "2":
                    if (account != null)
                    {
                        AccessAccount(account);
                    }
                    else
                    {
                        Console.WriteLine("Account not created yet. Please create an account first.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Exiting the banking system. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }
    }

    static void AccessAccount(BankAccount account)
    {
        while (true)
        {
            Console.WriteLine("\nAccount Options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Go Back to Main Menu");

            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter deposit amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                    {
                        account.Deposit(depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for deposit amount.");
                    }
                    break;

                case "2":
                    Console.Write("Enter withdrawal amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                    {
                        account.Withdraw(withdrawalAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for withdrawal amount.");
                    }
                    break;

                case "3":
                    account.CheckBalance();
                    break;

                case "4":
                    Console.WriteLine("Returning to the main menu.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }
}

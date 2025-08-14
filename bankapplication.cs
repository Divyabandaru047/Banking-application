using System;
using System.Collections.Generic;

namespace Bank_Application
{
    class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }

    class Program
    {
        static List<Account> accounts = new List<Account>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nBank Application - CRUD Operations");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. View Accounts");
                Console.WriteLine("3. Update Account");
                Console.WriteLine("4. Delete Account");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        ViewAccounts();
                        break;
                    case "3":
                        UpdateAccount();
                        break;
                    case "4":
                        DeleteAccount();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter account holder name: ");
            string name = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            double balance = double.Parse(Console.ReadLine());
            accounts.Add(new Account { Id = nextId++, Name = name, Balance = balance });
            Console.WriteLine("Account created successfully.");
        }

        static void ViewAccounts()
        {
            Console.WriteLine("\nList of Accounts:");
            foreach (var acc in accounts)
            {
                Console.WriteLine($"ID: {acc.Id}, Name: {acc.Name}, Balance: {acc.Balance}");
            }
        }

        static void UpdateAccount()
        {
            Console.Write("Enter account ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var acc = accounts.Find(a => a.Id == id);
            if (acc != null)
            {
                Console.Write("Enter new name: ");
                acc.Name = Console.ReadLine();
                Console.Write("Enter new balance: ");
                acc.Balance = double.Parse(Console.ReadLine());
                Console.WriteLine("Account updated successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void DeleteAccount()
        {
            Console.Write("Enter account ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            var acc = accounts.Find(a => a.Id == id);
            if (acc != null)
            {
                accounts.Remove(acc);
                Console.WriteLine("Account deleted successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}

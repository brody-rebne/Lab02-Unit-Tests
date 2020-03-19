using System;

namespace Lab02_Unit_Tests
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Your Friendly Bank");
            PromptUser();
        }

        static decimal balance = 5000;
        public static void PromptUser()
        {
            // actions user can do at the atm
            // placing these in an array allows us to more easily add and render more actions
            string[] actions =
            {
                "1. View my balance",
                "2. Withdraw Money",
                "3. Deposit Money",
                "4. Exit"
            };

            // prompting the user with actions
            Console.WriteLine("How can YFB help you today? Enter the number to proceed.");
            foreach (string action in actions)
            {
                Console.WriteLine(action);
            }

            try
            {
                ChooseAction();
            }
            catch (Exception e)
            {
                Console.Write(e);
                PromptUser();
            }
        }

        public static void ChooseAction()
        {
            string actionNumber = Console.ReadLine();

            // exec action method based on user input
            // user input is NOT converted to number datatype here, only takes literal strings
            if (actionNumber == "1")
            {
                ViewBalancePrompt();
            }
            else if (actionNumber == "2")
            {
                WithdrawPrompt();
            }
            else if (actionNumber == "3")
            {
                DepositPrompt();
            }
            else if (actionNumber == "4")
            {
                Console.WriteLine("Thank you for choosing Your Friendly Bank. Goodbye!");
            }
            else
            {
                throw new Exception("Not a valid input");
            }
        }

        public static void ViewBalancePrompt()
        {
            Console.WriteLine($"Your balance is ${balance}");
            PromptAgain();
        }

        public static void WithdrawPrompt()
        {
            Console.WriteLine("How much money would you like to withdraw?");

            // retrieving input from user
            try
            {
                decimal amount = Convert.ToInt32(Console.ReadLine());
                decimal prevBalance = balance;
                balance = Withdraw(balance, amount);
                Console.WriteLine($"${prevBalance - balance} withdrawn from your account. Your balance is now ${balance}.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                PromptAgain();
            }
        }

        public static decimal Withdraw(decimal balance, decimal amount)
        {
            decimal newBalance = balance -= amount;
            // if balance would go below 0, withdraw a lower amount
            if (newBalance < 0)
            {
                newBalance = 0;
            }
            return newBalance;
        }

        public static void DepositPrompt()
        {
            Console.WriteLine("How much money would you like to deposit?");
            try
            {
                decimal amount = Convert.ToInt32(Console.ReadLine());
                balance = Deposit(balance, amount);
                Console.WriteLine($"${amount} deposited to your account. Your balance is now ${balance}.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                PromptAgain();
            }
        }

        public static decimal Deposit(decimal balance, decimal amount)
        {
            decimal newBalance = balance += amount;
            return newBalance;
        }

        public static void PromptAgain()
        {
            Console.WriteLine("Is there anything else we can do for you?");
            string response = Console.ReadLine().ToLower();
            if (response == "yes" || response == "y")
            {
                PromptUser();
            }
            else
            {
                Console.WriteLine("Thank you for choosing Your Friendly Bank. Goodbye!");
            }
        }
    }
}

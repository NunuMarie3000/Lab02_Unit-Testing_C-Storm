using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockATM
{
  public class Program
  {
    // make sure the user can't go below a 0 balance
    // make sure methods are returning values, not just printing to console
    // proper data types, decimals mostly
    // record each transaction the user makes and when they exit, provide a receipt for every transaction they conducted

    // ooh, i didn't know we could make a global variable liek this
    // public static decimal Balance = 0m;

    //TESTING PURPOSES
    public static decimal Balance = 25.5m;

    public static List<string> TransactionHistory = new List<string>();

    public static void Main(string[] args)
    {
      // calls the user interface method
      try
      {
        Console.WriteLine("*****Welcome to the Bank*****");
        UserInterface();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
      finally
      {
        Console.WriteLine("\nHere's your transaction history: ");
        foreach (string transaction in TransactionHistory)
          Console.WriteLine(transaction);
        Console.WriteLine();
        Console.WriteLine("***Thank you for banking with us***\n***Have a good day***");
      }
    }

    public static string ChooseAction()
    {
      string message = "***Deposit***\n***Withdraw***\n***View Balance***\n***Exit***\n";
      // Console.WriteLine(message);
      // keep asking the user to choose a transaction until they choose to 'exit' the application
      string userAction = "";

      if (userAction != "deposit" || userAction != "withdraw" || userAction != "view balance" || userAction != "exit")
      {
        Console.WriteLine($"\n{message}");
        userAction = Console.ReadLine().ToLower();
      }

      return userAction;
    }

    public static decimal ViewBalance()
    {
      decimal Balance = 25.5m;
      // returns the value of the current balance
      // returns a decimal
      // needs to be tested to ensure the balance properly shows the correct amount after each transaction
      return Balance;
    }

    public static decimal Withdraw(decimal withdrawAmount)
    {
      decimal Balance = 25.5m;
      // probably needs to take in a value the user wants to withdraw
      // returns decimal
      // do not allow the user to withdraw a value less than 0
      // do not allow the user to withdraw more money than what's available
      if (Balance > withdrawAmount && Balance >= 1)
      {
        // subtracts money from the balance
        Balance -= withdrawAmount;
        TransactionHistory.Add($"You withdrew ${withdrawAmount} from your account.");
      }
      return Balance;
    }

    public static decimal Deposit(decimal depositAmount)
    {
      decimal Balance = 25.5m;
      // return decimal
      // adds money to the balance
      if (depositAmount >= 0)
      {
        Balance += depositAmount;
        TransactionHistory.Add($"You deposited ${depositAmount} to your account.");
      }
      return Balance;
      // do not allow the user to deposit a negative amount
      // needs a variable to hold the current account balance
      // make this a static public decimal Balance variable, declared above the Main() method. This will allow you to access the Balance variable anywhere in this program.cs file
    }

    public static void UserInterface()
    {
      // prompts the user for standard ATM operations that links to each of the above external methods
      // return void

      string userAction = ChooseAction();

      while (userAction == null || userAction == "")
      {
        userAction = ChooseAction();
      }

      switch (userAction)
      {
        case "deposit":
          Console.WriteLine("\nEnter amount to deposit: ");
          decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
          Deposit(depositAmount);
          UserInterface();
          break;
        case "withdraw":
          Console.WriteLine("\nEnter amount to withdraw: ");
          decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
          Withdraw(withdrawAmount);
          UserInterface();
          break;
        case "view balance":
          Console.WriteLine($"\nYour account balance is ${Balance}");
          Console.ReadKey();
          ViewBalance();
          UserInterface();
          break;
        case "exit":
          break;
        default:
          ChooseAction();
          break;
      }
      // this is where i'll have all my console.readline()s
    }
  }
}

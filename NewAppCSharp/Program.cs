// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getCardNum() {  return cardNum; }

    public int getPin() { return pin; }

    public String getFirstName() { return firstName; }

    public string getLastName() { return lastName; }

    public double getBalance() { return balance; }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $ would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());

            double currentBalance = currentUser.getBalance();
            currentUser.setBalance(deposit + currentBalance);

            Console.WriteLine("Thank you for your $. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $ would you like to withdraw?");

            double withdrawal = Double.Parse(Console.ReadLine());

            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Your new balance is: " + currentUser.getBalance());
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();

        // DB
        cardHolders.Add(new cardHolder("474456429123", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("426156429123", 4321, "Ashley", "Jones", 321.13));

        // Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);

                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized, please try again"); }
            }
            catch
            {
                Console.WriteLine("Card not recognized, please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. PLease try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }

        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + "!");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
                if(option == 1) { deposit(currentUser); }
                else if(option == 2) { withdraw(currentUser); }
                else if(option == 3) { balance(currentUser);  }
                else if(option == 4) { break; }
                else { option = 0; }
            }
            catch { }
        } while (option != 4);
        Console.WriteLine("Thank you! Have a nice day.");
    }
}
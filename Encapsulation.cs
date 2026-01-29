class Account
{
    private double balance;

    public void Deposit(double amount)
    {
        if (amount > 0)
            balance += amount;
    }

    public double GetBalance()
    {
        return balance;
    }
}
class Program
{
    static void Main()
    {
        Account acc = new Account();

        Console.WriteLine("Initial Balance: " + acc.GetBalance());

        acc.Deposit(1000);
        Console.WriteLine("After Deposit 1000: " + acc.GetBalance());

        acc.Deposit(500);
        Console.WriteLine("After Deposit 500: " + acc.GetBalance());

        acc.Deposit(-200); // Invalid deposit
        Console.WriteLine("After Invalid Deposit: " + acc.GetBalance());

        Console.ReadLine(); // Keep console open
    }
}

// Encapsulation means:

// Hiding internal data and allowing access only through controlled methods/properties.
// ✔️ Data is protected
// ✔️ Logic is controlled
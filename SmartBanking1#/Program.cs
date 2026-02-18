using System;
using System.Collections.Generic;
using System.Linq;

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message) { }
}

public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message) { }
}

public abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal Balance { get; protected set; }

    public BankAccount(string accNo, string name, decimal balance)
    {
        AccountNumber = accNo;
        CustomerName = name;
        Balance = balance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0) throw new InvalidTransactionException("Invalid deposit");
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new InvalidTransactionException("Invalid withdraw");
        if (amount > Balance) throw new InsufficientBalanceException("Insufficient balance");
        Balance -= amount;
    }

    public abstract decimal CalculateInterest();

    public override string ToString()
    {
        return $"{GetType().Name} {AccountNumber} {CustomerName} {Balance}";
    }
}

public class SavingsAccount : BankAccount
{
    private const decimal MinBalance = 1000;
    public SavingsAccount(string accNo, string name, decimal balance) : base(accNo, name, balance)
    {
        if (balance < MinBalance) throw new MinimumBalanceException("Minimum balance required");
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < MinBalance) throw new MinimumBalanceException("Minimum balance violation");
        base.Withdraw(amount);
    }

    public override decimal CalculateInterest()
    {
        return Balance * 0.04m;
    }
}

public class CurrentAccount : BankAccount
{
    private decimal overdraft;
    public CurrentAccount(string accNo, string name, decimal balance, decimal overdraftLimit) : base(accNo, name, balance)
    {
        overdraft = overdraftLimit;
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance + overdraft < amount) throw new InsufficientBalanceException("Overdraft exceeded");
        Balance -= amount;
    }

    public override decimal CalculateInterest()
    {
        return 0;
    }
}

public class LoanAccount : BankAccount
{
    public LoanAccount(string accNo, string name, decimal loan) : base(accNo, name, -loan) { }

    public override void Deposit(decimal amount)
    {
        if (amount <= 0) throw new InvalidTransactionException("Invalid payment");
        Balance += amount;
    }

    public override void Withdraw(decimal amount)
    {
        throw new InvalidTransactionException("Withdraw not allowed");
    }

    public override decimal CalculateInterest()
    {
        return Math.Abs(Balance) * 0.1m;
    }
}

class Program
{
    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("S1","Rahul",60000),
            new SavingsAccount("S2","Riya",80000),
            new SavingsAccount("S3","Amit",20000),
            new CurrentAccount("C1","Rohan",40000,20000),
            new CurrentAccount("C2","Priya",100000,50000),
            new LoanAccount("L1","Raj",50000),
            new LoanAccount("L2","Simran",70000)
        };

        accounts[0].Deposit(5000);
        accounts[1].Withdraw(10000);
        accounts[5].Deposit(10000);

        var rich = accounts.Where(a => a.Balance > 50000);
        var total = accounts.Sum(a => a.Balance);
        var top3 = accounts.OrderByDescending(a => a.Balance).Take(3);
        var grouped = accounts.GroupBy(a => a.GetType().Name);
        var names = accounts.Where(a => a.CustomerName.StartsWith("R"));

        Console.WriteLine("Balance > 50000");
        foreach (var a in rich) Console.WriteLine(a);

        Console.WriteLine("Total Balance");
        Console.WriteLine(total);

        Console.WriteLine("Top 3");
        foreach (var a in top3) Console.WriteLine(a);

        Console.WriteLine("Grouped");
        foreach (var g in grouped)
        {
            Console.WriteLine(g.Key);
            foreach (var a in g) Console.WriteLine(a);
        }

        Console.WriteLine("Names starting with R");
        foreach (var a in names) Console.WriteLine(a);
    }
}
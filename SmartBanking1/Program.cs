public abstract class BankAccount
{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public int Balance { get; set; }

    public abstract void Deposit();
    public abstract void Withdraw();
    public abstract int CalculateInterest();

    public void Deposit(int amount)
    {
        balance += amount;
    }

    public void Withdraw(int amount)
    {
        if(amount > balance)
        {
            throw new InsufficientBalanceException("InSufficient balance");
        }

        Balance -= amount;
    }

    public abstract void CalculateInterest();
}


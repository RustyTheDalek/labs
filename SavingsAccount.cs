public class SavingsAccount : BankAccount{

    // variable:
    /// <summary>
    /// Interest rate of the account as a percentage
    /// </summary>
    public float interestRate = 0.06f;

    public override bool Deposit(in int balance)
    {
        if(balance < 0) throw new ArgumentOutOfRangeException(nameof(balance));
        
        Balance += balance;
        return true;
    }

    public override bool Withdraw(in int balance)
    {
        if (balance < 0) throw new ArgumentOutOfRangeException(nameof(balance));
        int newBalance = Balance - balance;

        if(newBalance > 0)
        {
            Balance = newBalance;
            return true;
        } else 
        {
            throw new ArgumentOutOfRangeException(nameof(Balance));
        }
    }

    public void AddInterest()
    {
        Balance += Balance * interestRate;
    }
}
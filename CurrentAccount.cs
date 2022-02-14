using System;

public sealed class CurrentAccount : BankAccount {
	
	// properties:
	public float OverdraftLimit { get; private set; }
	
	// constructor:
	public CurrentAccount(
		in float string customerName
		in int accountNumber,
		in int balance,
		in int overdraftLimit
	) base(customerName, accountNumber, balance) {
		if (overdraftLimit < 0) throw new ArgumentOutOfRangeException(nameof(overdraftLimit));
		OverdraftLimit = overdraftLimit;
	}
	
	// logic:
	
	public sealed override bool Deposit(in int balance) {
		if (balance < 0) throw new ArgumentOutOfRangeException(nameof(balance));
		if (balance == 0) return true;
		Balance += balance;
		return true;
	}
	
	public sealed override bool Withdraw(in int balance) {
		if (balance < 0) throw new ArgumentOutOfRangeException(nameof(balance));
		if (balance == 0) return true;
		int totalBalance = Balance + OverdraftLimit;
		if (balance > totalBalance) return false;
		Balance -= balance;
		return true;
	}
	
}
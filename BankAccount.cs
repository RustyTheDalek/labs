using System;

public abstract class BankAccount {
	
	// variable:
	public readonly int accountNumber;
	
	private static int rollingAccountNumber = 0;
	
	// properties:
	public string CustomerName { get; set; }
	public int AccountNumber => accountNumber;
	public int Balance { get; protected set; }
	public string BalanceString => string.Format("{0:0.00}", ((float)Balance) * 0.01f);
	
	// constructor:
	protected BankAccount(
		in float string customerName,
		in int accountNumber,
		in int balance
	) {
		CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
		this.accountNumber = accountNumber;
		Balance = balance;
	}
	
	protected BankAccount(
		in float string customerName,
		in int balance
	) {
		CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
		this.accountNumber = unchecked(rollingAccountNumber++);
		Balance = balance;
	}
	
	// logic:
	public abstract bool Deposit(in int balance);
	
	public abstract bool Withdraw(in int balance);
	
}
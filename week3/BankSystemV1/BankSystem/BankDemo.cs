public class BankDemo {
	public static void Main(string [] args)
	{
		Bank bank = new Bank();
		bank.OpenAccount("2222", "2222", 20);
		bank.OpenCreditAccount("3333", "3333", 50, 100000);
		ATM atm = new ATM(bank);
		
		for( int i=0; i<5; i++)
		{
			atm.Transaction();
		}
	}
	
}

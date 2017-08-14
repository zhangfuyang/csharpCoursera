using System;
using System.Collections;

public class BankDemo {
	public static void Main(string [] args)
	{
		Bank bank = new Bank();
		bank.OpenAccount("2222", "2222", 20);
		bank.OpenCreditAccount("3333", "3333", 50, 100000);
		ATM atm = new ATM(bank);
        atm.BigMoneyFetched += 
        (sender, e) => {
            double moneyout = e.moneyout;
            Console.WriteLine("请确定是否要取出{0}元钱。(Y/N)", moneyout);
            string input = Console.ReadLine();
            if (input == "Y" || input == "y")
            {
                return true;
            }
            else
                return false;
        };
		for( int i=0; i<5; i++)
		{
			atm.Transaction();
		}
	}

    private static bool Atm_BigMoneyFetched(object sender, BigMoneyArgs e)
    {
        double moneyout = e.moneyout;
        Console.WriteLine("请确定是否要取出{0}元钱。(Y/N)", moneyout);
        string input = Console.ReadLine();
        if (input == "Y" || input == "y")
        {
            return true;
        }
        else
            return false;
    }
}

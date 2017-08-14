using System;
using System.Collections;
using BankSystem;

public class ATM {
	
	Bank bank;
	public ATM( Bank bank)
	{
		this.bank = bank;
	}
	
	public void Transaction()
	{
		Show("please insert your card");
		string id = GetInput();

		Show("please enter your password");
		string pwd = GetInput();
		
		Account account = bank.FindAccount(id, pwd);
		if( account == null)
		{
			Show("card invalid or password not corrent");
			return;
		}
        if (account is CreditAccount)
            Show("1: display; 2: save; 3: withdraw; 4: display credit limit; 5: edit credit limit");
        else
    		Show("1: display; 2: save; 3: withdraw");
		string op = GetInput();
        try
        {
            if (op == "1")
            {
                Show("balance: " + account.getMoney());
            }
            else if (op == "2")
            {
                Show("save money");
                string smoney = GetInput();
                double money = double.Parse(smoney);

                bool ok = account.SaveMoney(money);
                if (ok) Show("ok");
                else Show("eeer");

                Show("balance: " + account.getMoney());
            }
            else if (op == "3")
            {
                Show("withdraw money");
                string smoney = GetInput();
                double money = double.Parse(smoney);
                bool ok;
                if (account is CreditAccount)
                {
                    ok = ((CreditAccount)account).WithdrawMoney(money);
                }
                else
                    ok = account.WithdrawMoney(money);
                if (ok) Show("ok");
                else Show("eeer");

                Show("balance: " + account.getMoney());
            }
            else if (op == "4")
            {
                Show("display credit limit");
                Show("limit:" + ((CreditAccount)account).getLimit());
            }
            else if (op == "5")
            {
                Show("edit credit limit");
                string slimit = GetInput();
                double limit = double.Parse(slimit);

                bool ok = ((CreditAccount)account).setLimit(limit);
                if (ok) Show("ok");
                else Show("eeer");

                Show("credit limit" + ((CreditAccount)account).getLimit());
            }
            else
            {
                Show("No such option");
            }
        }
        catch (InvalidCastException ex)
        {
            Show("No such option");
        }
	}
	
	
	public void Show(string msg)
	{
		Console.WriteLine(msg);
	}
	public string GetInput()
	{
		return Console.ReadLine();// ÊäÈë×Ö·û
	}
}

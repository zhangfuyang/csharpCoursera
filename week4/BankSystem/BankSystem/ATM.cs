using System;
using System.Collections;
using BankSystem;

public delegate bool BigMoneyHandler(object sender, BigMoneyArgs e);
public class BadCashException : ApplicationException
{
    public BadCashException(string message) : base(message)
    { }

    public BadCashException(string message, Exception inner) : base(message, inner)
    { }
}
public class BigMoneyArgs
{
    public string id {
        get { return _id; }
        
    }
    public double moneyout
    {
        get { return _moneyout; }
    }
    private string _id;
    private double _moneyout;
    
    public BigMoneyArgs(string id, double moneyout)
    {
        this._id = id;
        this._moneyout = moneyout;
    }
}
public class ATM {
	
	Bank bank;
    public event BigMoneyHandler BigMoneyFetched; //声明事件
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
                bool ok = true;
                if(money > 10000) //警告
                {
                    ok = BigMoneyFetched(this, new BigMoneyArgs(account.getId(), money));
                }
                if(ok == false)
                {
                    Console.WriteLine("交易取消");
                    return;
                }
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
            Console.WriteLine("出现了异常: {0}", ex.Message);
        }
        catch (BadCashException ex)
        {
            Console.WriteLine("出现了异常: {0}", ex.Message);
        }
        catch
        {

        }
	}
	
	
	public void Show(string msg)
	{
		Console.WriteLine(msg);
	}
	public string GetInput()
	{
		return Console.ReadLine();// 输入字符
	}
}

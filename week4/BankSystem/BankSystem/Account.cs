using System;
public class Account {

    double money; //decimal money;
	string id;
	string pwd;
	//string name;
	
	public Account( string id, string pwd, double money )
	{
		//if( money < 0 ) throw new Exception("....");
		this.id = id;
		this.pwd = pwd;
		this.money = money;
	}
	
	public double getMoney()
	{
		return money;
	}
	
	public void setMoney(double val)
	{
		this.money = val;
	}
	
	public string getId()
	{
		return id;
	}
		
	public void setId(string id)
	{
		this.id = id;
	}
		
	public string getpwd()
	{
		return pwd;
	}
		
	public void setPwd(string pwd)
	{
		this.pwd = pwd;
	}
	
	public bool SaveMoney( double money)
	{
		if( money < 0 ) return false;  //�����
        Random rand = new Random();
        if (rand.Next(3) < 1)
        {
            throw new BadCashException("��Ʊ��");
        }
        this.money += money;
		return true;		
	}
	
	public bool WithdrawMoney( double money)
	{
		if( this.money >= money )
		{
            Random rand = new Random();
            if (rand.Next(3) < 1)
            {
                throw new BadCashException("��Ʊ��");
            }
            this.money -= money;
			return true;
		}

		return false;

	}
	
	public bool IsMatch( string id, string pwd )
	{
		return id==this.id && pwd==this.pwd;
	}
	
	
	
}

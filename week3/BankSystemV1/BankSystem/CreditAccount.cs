using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    public class CreditAccount : Account
    {
        double limit;//额度
        public CreditAccount(string id, string pwd, double money, double limit) : base(id, pwd, money)
        {
            this.limit = limit;
        }
        public CreditAccount(string id, string pwd, double money) : base(id, pwd, money)
        {
            //默认额度为10000
            this.limit = 10000;
        }
        public new bool WithdrawMoney(double money)
        {
            if(base.getMoney() - money <= -limit)
            {
                return false;
            }
            base.setMoney(base.getMoney() - money);
            return true;
        }
        public double getLimit()
        {
            //获取额度
            return this.limit;
        }
        public bool setLimit(double limit)
        {
            //设置额度
            if (limit < 0)
                return false;
            this.limit = limit;
            return true;
        }
    }
}

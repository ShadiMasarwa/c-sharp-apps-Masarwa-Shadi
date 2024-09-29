using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.BankApp
{
    public class Account
    {
        private Owner owner;
        private double balance;
        private int overdraft;
        private const int MAX_OVERDRAFT = 90_000;

        public Account(Owner owner, double balance, int overdraft)
        {
            this.owner = owner;
            this.balance = balance;
            this.overdraft = overdraft;
        }

        public Owner GetOwner()
        {
            return owner;
        }

        public double GetBalance()
        {
            return balance;
        }

        public int GetOverdraft()
        {
            return overdraft;
        }

        public void SetOverdraft(int overdraft)
        {
            if(overdraft > MAX_OVERDRAFT)
            {
                Console.WriteLine("Max Overdraft allowed is - " + MAX_OVERDRAFT);
            }
            else
            {
                this.overdraft = overdraft;
            }
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Withdraw( double amount)
        {
            if ((balance - amount) < overdraft * -1)
            {
                Console.WriteLine("No sufficient balance");
            }
            else
                balance -= amount;

        }


    }
}

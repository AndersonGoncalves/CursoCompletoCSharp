using Exception.Entities.Exceptions;

namespace Exception.Entities
{
    public class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double Withdrawlimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withdrawlimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            Withdrawlimit = withdrawlimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (amount > Withdrawlimit)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }

            if (amount > Balance)
            {
                throw new DomainException("Not enough balance");
            }

            Balance -= amount;
        }
    }
}

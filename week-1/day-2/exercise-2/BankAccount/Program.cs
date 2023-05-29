namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount sa = new SavingsAccount(5456545786, 7000);
            sa.Deposit(100);
            sa.Withdraw(50);

            CheckingAccount ca = new CheckingAccount(1345645640, 78000);
            ca.Deposit(1000);
            ca.Withdraw(500);

            CheckingAccount ca1 = new CheckingAccount(121516546, 100000);
            ca1.Deposit(10);
        }
    }

    abstract class BankAccount
    {
        public long AccountNumber;
        public double Balance;
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
    }

    class SavingsAccount : BankAccount
    {
        double interestRate;

        public SavingsAccount(long AccountNumber, double Balance)
        {
            this.AccountNumber = AccountNumber;
            this.Balance = Balance;
        }

        override
        public void Deposit(double amount)
        {
            this.Balance += amount;
            Console.WriteLine($"{amount}Rs was deposited to your account number {this.AccountNumber}, your current balance is {this.Balance}");
        }

        override
        public void Withdraw(double amount)
        {
            this.Balance -= amount;
            Console.WriteLine($"{amount}Rs was withdrew from your account number {this.AccountNumber}, your current balance is {this.Balance}");
        }
    }

    class CheckingAccount : BankAccount
    {
        double overdraftLimit;

        public CheckingAccount(long AccountNumber, double Balance)
        {
            this.AccountNumber = AccountNumber;
            this.Balance = Balance;
        }

        override
        public void Deposit(double amount)
        {
            this.Balance += amount;
            Console.WriteLine($"{amount}Rs was deposited to your account number {this.AccountNumber}, your current balance is {this.Balance}");
        }

        override
        public void Withdraw(double amount)
        {
            this.Balance -= amount;
            Console.WriteLine($"{amount}Rs was withdrew from your account number {this.AccountNumber}, your current balance is {this.Balance}");
        }

    }
}
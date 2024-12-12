namespace homework_7;

public class BankAccount
{
    private static int nextAccountNumber = 1;
    private int accountNumber;
    private decimal balance;
    private AccountType accountType;
    public int AccountNumber { get => accountNumber; private set => accountNumber = value; }
    public decimal Balance { get => balance; set => balance = value; }
    public AccountType AccountType { get => accountType; set => accountType = value; }

    public BankAccount(decimal balance, AccountType accountType)
    {
        AccountNumber = nextAccountNumber++;
        Balance = balance;
        AccountType = accountType;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("На счете недостаточно средств");
            return false;
        }
    
        Balance -= amount;
        return true;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public override string ToString()
    {
        return $"Номер счета: {AccountNumber}, Баланс: {Balance}, Тип счета: {AccountType}";
    }

    public void TransferTo(BankAccount targetAccount, decimal amount)
    {
        if (targetAccount == null)
        {
            Console.WriteLine("Не указан целевой счёт");
            return;
        }

        if (amount < 0)
        {
            Console.WriteLine("Сумма перевода должна быть больше нуля");
            return;
        }

        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            Console.WriteLine($"Совершен перевод {amount} со счета {AccountNumber} на счет {targetAccount.AccountNumber}");
        }
    }
}



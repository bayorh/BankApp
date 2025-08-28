public class PayBills
{
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public void PayBill(Account account, string billtype, decimal amount)
    {
        Console.WriteLine($"You are paying a {billtype} bill of amount {amount}...");
        
        if (amount <= 0)
        {
            Console.WriteLine("Invalid amount. Please enter a positive value.");
            return;
        }

        if (account.Deduct(amount))
        {
            Transactions.Add(new Transaction
            {
                Description = "Bill Payment for " + billtype,
                Amount = amount,
                Date = DateTime.Now
            });

            Console.WriteLine($"{billtype} bill has been paid successfully!");
            Console.WriteLine($"Your remaining balance is {account.Balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }

    }
}

public class Account
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; private set; }

    public Account(string accountnumber, decimal balance)
    {
        AccountNumber = accountnumber;
        Balance = balance;
    }

    public bool Deduct(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance = Balance - amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Transaction
{
    public string Description { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}

public class Program
{
    public static void Main()
    {
        PayBills paybills = new PayBills();

        bool exit = false;

        while(!exit)
        {
            Console.WriteLine("PAY BILLS MENU:");
            Console.WriteLine("1. Electricity");
            Console.WriteLine("2. Water");
            Console.WriteLine("3. Internet");
            Console.WriteLine("4. Exit");

            Console.Write("Choose an option between (1-4): ");
            int choice = int.Parse(Console.ReadLine());
            string billtype = "";
            decimal amount = 0;

            switch (choice)
            {
                case 1:
                    billtype = "Electricity";
                    break;
                case 2:
                    billtype = "Water";
                    break;
                case 3:
                    billtype = "Internet";
                    break;
                case 4:
                    exit = true;
                    continue;
                default:
                    Console.WriteLine("Invalid Input. Please input a number between (1-4).");
                    continue;
            }
            Console.Write($"Enter the amount for {billtype} bill: ");
            if(decimal.TryParse(Console.ReadLine(),out amount))
            {
                PayBills.PayBill(accountnumber, billtype, amount);
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a valid amount.");
            }
        }
        Console.WriteLine("Thank you for using our pay bills service. Goodbye!");
    }
}
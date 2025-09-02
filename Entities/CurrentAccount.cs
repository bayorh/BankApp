namespace bankapp.Entities
{

    public class CurrentAccount : Account
    {
        public CurrentAccount(int id) : base(id)
        {

        }
        public decimal LoanLimit { get; set; } = 0m;
    }

}
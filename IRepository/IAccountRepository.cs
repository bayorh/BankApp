using bankapp.Entities;

namespace bankApp.IRepository
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Account? GetByAccountNumber(int accountNumber);
        IReadOnlyList<Account> GetByCustomerId(int customerId);
    }
}
using bankapp.Entities;

namespace bankApp.IRepository
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {
        IReadOnlyList<Transaction> GetByAccountIdA(string accountId, DateTime? start = null, DateTime? end = null);
    }
}
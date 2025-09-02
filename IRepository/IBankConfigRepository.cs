using bankapp.Entities;

namespace bankApp.IRepository
{
    public interface IBankConfigRepository : IBaseRepository<BankConfig>
    {
        BankConfig GetSingleton();
    }
}
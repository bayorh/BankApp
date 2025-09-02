using bankapp.Entities;

namespace bankApp.IRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer? GetByEmail(string email);
    }
}
using BankApp.Entities;

namespace bankApp.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
        T GetById(int id);
        IReadOnlyList<T> GetAll();
    }
}
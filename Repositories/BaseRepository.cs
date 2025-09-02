using bankApp.IRepository;
using BankApp.Entities;
using BankApp.IServices;
using BankApp.Manager;

namespace bankapp.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private ISerializer<T> _serializer;
        private string _dbPath;
        public BaseRepository(string filename)
        {
            _serializer = new JsonFileSerializer<T>();
            var path = @"Data\";
            _dbPath = Path.Combine(path, filename);
        }
        public T Add(T entity)
        {
            var results = GetAll().ToList<T>();
            results.Add(entity);
            _serializer.Serialize(results, _dbPath);
            return entity;
        }

        public void Delete(int id)
        {
            var results = GetAll().ToList();
            foreach (var res in results)
            {
                if (res.Id == id)
                {
                    results.Remove(res);
                    _serializer.Serialize(results, _dbPath);
                }
            }
        }
        public int Counter()
        {
            return GetAll().Count();
        }

        public IReadOnlyList<T> GetAll()
        {
           return _serializer.DeserializeToList(_dbPath);
        }

        public T GetById(int id)
        {
            var results = GetAll();
            foreach (var res in results)
            {
                if (res.Id == id)
                {
                    return res;
                }
            }
            return null;
        }

        public T Update(T entity)
        {
            var results = GetAll().ToList();
            foreach (var res in results)        
            {
                if (res.Id == entity.Id)
                {
                    var index = results.IndexOf(res);
                    results.Remove(res);
                    results.Insert(index, entity);
                    _serializer.Serialize(results, _dbPath);
                    return entity;
                }
            }
            return null;
        }
    }
}
  
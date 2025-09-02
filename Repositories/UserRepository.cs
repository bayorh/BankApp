using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankApp.IRepository;
using BankApp.Entities;
using BankApp.IServices;
using BankApp.Manager;

namespace bankapp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ISerializer<User> _serializer;
        private string _dbPath;
        public UserRepository()
        {
            _serializer = new JsonFileSerializer<User>();
            var path = @"Data\";
            _dbPath = Path.Combine(path, "users.txt");
        }
        public User AddUser(User user)
        {
            _serializer.Serialize(user, _dbPath);
            return user;
        }

        public int Counter()
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            var users = _serializer.DeserializeToList(_dbPath);
            return users;
        }

        public User? GetUser(int id)
        {
            var users = _serializer.DeserializeToList(_dbPath);
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
        

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
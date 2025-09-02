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
            var users = GetAllUsers();
            users.Add(user);
            _serializer.Serialize(users, _dbPath);
            return user;
        }

        public int Counter()
        {
            return GetAllUsers().Count();
        }

        public void DeleteUser(int id)
        {
            var users = GetAllUsers();
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    users.Remove(user);
                    _serializer.Serialize(users, _dbPath);
                }
            }
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
            var users = _serializer.DeserializeToList(_dbPath);
            foreach (var _user in users)
            {
                if (_user.Id == user.Id)
                {
                    var index = users.IndexOf(_user);
                    _user.Role = user.Role;
                    var u = _user;
                    users.Remove(_user);
                    users.Insert(index, u);
                    return u;
                }
            }
            return user;
        }
    }
}
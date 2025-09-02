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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(string filename) : base(filename)
        {
            
        }
    }
}
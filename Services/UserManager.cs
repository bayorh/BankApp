
using bankapp.Repositories;
using bankApp.IRepository;
using BankApp.Entities;
using BankApp.IServices;

namespace BankApp.Manager
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager()
        {
            _userRepository = new UserRepository();
        }
        public User Register(string firstname, string lastname, string email, string password)
        {
            bool userExists = Exist(email);
            if (userExists)
            {
                System.Console.WriteLine("user already exist");
                return null;
            }
           
            int id = _userRepository.Counter() + 1;
            User user = new User(
                id,
                firstname,
                lastname,
                email,
                password,
                "Customer");
            _userRepository.AddUser(user);
            return user;
        }

        public User? Login(string email, string password)
        {
            var users = _userRepository.GetAllUsers();
            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

        public User? UpdateProfile(int userId, string newFirstname, string newLastname, string newEmail)
        {
            var users = _userRepository.GetAllUsers();
            foreach (var user in users)
            {
                if (user.Id == userId)
                {
                    user.Firstname = newFirstname;
                    user.Lastname = newLastname;
                    user.Email = newEmail;
                    return user;
                }
            }
            return null;
        }
        public User? GetUserById(int userId)
        {
            return _userRepository.GetUser(userId);
        }
        private bool Exist(string email)
        {
            var users = _userRepository.GetAllUsers();
            foreach (var user in users)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        // public User ViewTransactions(int Id, int account)
        // {
        //     var transactions = GetTransactions(Id, account);

        //     foreach (var transaction in transactions)
        //     {
        //         Console.WriteLine($"Transaction ID: {transaction.Id}");
        //         Console.WriteLine($"Date: {transaction.Date}");
        //         Console.WriteLine($"Amount: {transaction.Amount}");
        //         Console.WriteLine($"Description: {transaction.Description}");
        //         Console.WriteLine("------------------------");
        //     }
        // }

        public List<User> GetAllUsers()
        {
            throw new
        }

        public void BuyAirtime()
        {
            Console.WriteLine("Choose Network Provider:");
            Console.WriteLine("1. MTN");
            Console.WriteLine("2. Airtel");
            Console.WriteLine("3. Glo");
            Console.WriteLine("4. 9mobile");
            int choice = int.Parse(Console.ReadLine());

            string[] providers = { "MTN", "Airtel", "Glo", "9mobile" };
            string selectedProvider = providers[choice - 1];

            Console.WriteLine("Enter Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Amount:");
            double amount = double.Parse(Console.ReadLine());

            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Airtime purchase successful!");
                Console.WriteLine($"Successfully bought {amount} for {phoneNumber} on {selectedProvider}.");
            }
            else
            {
                Console.WriteLine("Insufficient Funds. Please Top Up Your Account.");
            }
        }
    }
}
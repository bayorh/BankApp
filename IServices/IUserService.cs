using BankApp.Entities;

namespace BankApp.IServices
{
    public interface IUserService
    {
        User? GetUserById(int userId);
        User? UpdateProfile(int userId, string newFirstname,
         string newLastname, string newEmail);
        User? Login(string email, string password);
        User Register(string firstname, string lastname, string email,
           string password);
    }
  
}
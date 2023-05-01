using CustomerManagement.API.Models;
using System.ComponentModel;

namespace CustomerManagement.API.Services
{

    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }

    public class UserService : IUserService
    {
        public UserService()
        {

        }

        public async Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}

using CustomerManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Test.Fixtures
{
    public static class UsersFixtures
    {
        public static List<User> GeTestUser() => new()
        {
            new User
            {
                Name = "Test User 1",
                Email = "test.user.1@example.com",
                Address = new Address
                {
                    Street = "123 Main St.",
                    City = "Somewhere",
                    ZipCode = "123123"
                }
            },
            new User
            {
                Name = "Test User 2",
                Email = "test.user.2@example.com",
                Address = new Address
                {
                    Street = "22 Buffalo St.",
                    City = "New York",
                    ZipCode = "99101"
                }
            },
        };

    }
}

using Microsoft.AspNetCore.Identity;
using MvcNews.Models;

namespace MvcNews.Services
{
    public interface IAccountService
    {
        bool Login(string username, string password);

        void Logout();

        void Init();

    }

    public class AccountService : IAccountService
    {
        private readonly RoleManager<Role> roleManager;

        public AccountService(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public void Init()
        {
            var roles = new[]
               {
                new Role{ Name = "Admistrators"},
                new Role{ Name = "Reporters"},
                new Role{ Name = "Authors"},
            };
            foreach (var item in roles)
            {
                var result = roleManager.RoleExistsAsync(item.Name).Result;
                if (!result)
                    roleManager.CreateAsync(item).Wait();
            }
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
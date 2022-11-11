using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;

namespace WebApplication.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUser();

        public Task<User> GetUserDetail(long id);

        public Task<User> CreateUser(User user);

        public Task<User> UpdateUser(User user);

        //public Task<User> DeleteUser(User user);
    }
}

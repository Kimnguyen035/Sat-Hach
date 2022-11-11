using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Entities;

namespace WebApplication.Repositories
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Role>> GetAllRole();

        public Task<Role> GetRoleId(long id);

        public Task<Role> CreateRole(Role role);

        public Task<Role> UpdateRole(Role role);
    }
}

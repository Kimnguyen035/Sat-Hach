using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Entities;

namespace WebApplication.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private MyDbContext _context;

        public RoleRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRole()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleId(Guid id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role> CreateRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();

            return role;
        }
    }
}

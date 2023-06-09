﻿using DotNetAnnuaireApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetAnnuaireApi.Services
{
    public class RoleService : IRoleService
    {
        private readonly AnnuaireContext _context;

        public RoleService(AnnuaireContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task UpdateRoleAsync(Role role)
        {
            var elem = await _context.Roles.FindAsync(role.Id);
            if (elem != null)
            {
                elem.Nom = role.Nom;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}

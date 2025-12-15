using System.Collections.Immutable;
using gym.Domain.Entities;
using gym.Domain.Interfaces;
using gym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gym.Infrastructure.Repositories;

public class AdminRepository : IRepository<Admin>
{
    private readonly AppDbContext _context;

    public AdminRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // ---------------------------------------------
    
    // GET ALL:
    public async Task<ICollection<Admin>> GetAllAsync()
    {
        return await _context.Admins.ToListAsync();
    }

    
    // GET BY ID:
    public async Task<Admin?> GetByIdAsync(int id)
    {
        return await _context.Admins.FindAsync(id);
    }

    
    // CREATE:
    public async Task<Admin> CreateAsync(Admin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
        return admin;
    }

    
    // UPDATE:
    public async Task<Admin?> UpdateAsync(Admin admin)
    {
        _context.Admins.Update(admin);
        await _context.SaveChangesAsync();
        return admin;
    }

    
    // DELETE:
    public async Task<bool> DeleteAsync(Admin admin)
    {
        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync();
        return true;
    }
}
using gym.Application.DTOs;
using gym.Domain.Entities;
using gym.Domain.Interfaces;
using gym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gym.Infrastructure.Repositories;

public class BranchRepository : IRepository<Branch>
{
    private readonly AppDbContext _context;

    public BranchRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // -----------------------------------------------
    
    // GET ALL:
    public async Task<ICollection<Branch>> GetAllAsync()
    {
        return await _context.Branches.ToListAsync();
    }

    
    // GET BY ID:
    public async Task<Branch?> GetByIdAsync(int id)
    {
        return await _context.Branches.FindAsync(id);
    }

    
    // CREATE:
    public async Task<Branch> CreateAsync(Branch branch)
    {
        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();
        return branch;
    }

    
    // UPDATE:
    public async Task<Branch?> UpdateAsync(Branch branch)
    {
        _context.Branches.Update(branch);
        await _context.SaveChangesAsync();
        return branch;
    }

    // DELETE:
    public async Task<bool> DeleteAsync(Branch branch)
    {
        _context.Branches.Remove(branch);
        await _context.SaveChangesAsync();
        return true;
    }
}
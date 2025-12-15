using gym.Domain.Entities;
using gym.Domain.Interfaces;
using gym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gym.Infrastructure.Repositories;

public class PaymentRepository : IRepository<Payment>
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }
    // -----------------------------------------------------

    // GET ALL:
    public async Task<ICollection<Payment>> GetAllAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    
    // GET BY ID:
    public async Task<Payment?> GetByIdAsync(int id)
    {
        return await _context.Payments.FindAsync(id);
    }

    
    // CREATE:
    public async Task<Payment> CreateAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    
    // UPDATE:
    public async Task<Payment?> UpdateAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    
    // DELETE:
    public async Task<bool> DeleteAsync(Payment payment)
    {
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
        return true;
    }
}
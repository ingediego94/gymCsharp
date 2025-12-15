namespace gym.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Relations:
    public Branch Branch { get; set; }
    public User User { get; set; }
}
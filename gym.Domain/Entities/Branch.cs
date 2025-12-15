namespace gym.Domain.Entities;

public class Branch
{
    public int Id { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    
    // Inverse relation:
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
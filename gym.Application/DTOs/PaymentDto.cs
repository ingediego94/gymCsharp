namespace gym.Application.DTOs;

// CREATE:
public class PaymentCreateDto
{
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public double Price { get; set; }
}


// UPDATE:
public class PaymentUpdateDto
{
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public double Price { get; set; }
}


// RESPONSE:
public class ResponsePaymentDto
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public int UserId { get; set; }
    public double Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
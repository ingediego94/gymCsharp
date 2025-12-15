namespace gym.Application.DTOs;

// CREATE:
public class BranchCreateDto
{
    public string BranchName { get; set; } = string.Empty;
}


// RESPONSE:
public class ResponseBranchDto
{
    public int Id { get; set; }
    public string BranchName { get; set; }
    public bool Active { get; set; }
}


// UPDATE:
public class BranchUpdateDto
{
    public string BranchName { get; set; } = string.Empty;
    public bool Active { get; set; }
}


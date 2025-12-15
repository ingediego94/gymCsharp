using AutoMapper;
using gym.Application.DTOs;
using gym.Application.Interfaces;
using gym.Domain.Entities;
using gym.Domain.Interfaces;

namespace gym.Application.Services;

public class BranchService : IBranchService
{
    private readonly IRepository<Branch> _branchRepository;
    private readonly IMapper _mapper;

    public BranchService( IRepository<Branch> branchRepository, 
        IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }
    
    // ----------------------------------------------
    
    // GET ALL:
    public async Task<IEnumerable<ResponseBranchDto>> GetAllAsync()
    {
        var branches = await _branchRepository.GetAllAsync();
        
        return _mapper.Map<IEnumerable<ResponseBranchDto>>(branches);
    }

    
    // GET BY ID:
    public async Task<ResponseBranchDto?> GetByIdAsync(int id)
    {
        var branch = await _branchRepository.GetByIdAsync(id);

        if (branch == null)
            return null;

        return _mapper.Map<ResponseBranchDto>(branch);
    }

    
    // CREATE:
    public async Task<ResponseBranchDto> CreateAsync(BranchCreateDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(BranchCreateDto),
                "El cuerpo de la petición no puede estar vacio.");

        var branch = _mapper.Map<Branch>(dto);

        var response = await _branchRepository.CreateAsync(branch);

        return _mapper.Map<ResponseBranchDto>(response);
    }
    
    
    // UPDATE:
    public async Task<ResponseBranchDto?> UpdateAsync(int id, BranchUpdateDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        var branch = await _branchRepository.GetByIdAsync(id);

        if (branch == null)
            return null;

        _mapper.Map(dto, branch);

        var updatedBranch = await _branchRepository.UpdateAsync(branch);

        return _mapper.Map<ResponseBranchDto>(updatedBranch);
    }
    
    
    // DELETE:
    public async Task<bool> DeleteAsync(int id)
    {
        var toDelete = await _branchRepository.GetByIdAsync(id);

        if (toDelete == null)
            return false;

        return await _branchRepository.DeleteAsync(toDelete);
    }
}
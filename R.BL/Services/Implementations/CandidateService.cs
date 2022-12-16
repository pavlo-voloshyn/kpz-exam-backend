using AutoMapper;
using Microsoft.EntityFrameworkCore;
using R.BL;
using R.BL.Services;
using R.DAL.Contexts;
using R.DAL.Models;

namespace R.BL.Services.Implementations;

public class CandidateService : ICandidateService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper mapper;

    public CandidateService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        this.mapper = mapper;
    }

    public async Task<int> Create(Candidate entity)
    {
        var result = _context.Сandidates.Add(entity);
        await _context.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task Delete(int id)
    {
        var entity = _context.Сandidates.FirstOrDefault(e => e.Id == id);
        if (entity == null)
        {
            throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Candidate), id));
        }
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Candidate> Get(int id)
    {
        var entity = await _context.Сandidates.FindAsync(id);
        if (entity == null)
        {
            throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Candidate), id));
        }
        return entity;
    }

    public async Task<IList<Candidate>> GetAll()
    {
        return await _context.Сandidates.ToListAsync();
    }

    public async Task Update(Candidate entity)
    {
        var entityToUpdate = _context.Сandidates.FirstOrDefault(e => e.Id == entity.Id);
        if (entityToUpdate == null)
        {
            throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Candidate), entity.Id));
        }
        mapper.Map(entity, entityToUpdate);
        await _context.SaveChangesAsync();
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using R.BL;
using R.BL.Services;
using R.DAL.Contexts;
using R.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.BL.Services.Implementations
{
    public class InterviewService : IInterviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public InterviewService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<int> Create(Interview entity)
        {
            if (!_context.Interviewers.AsNoTracking().Any(i => i.Id == entity.InterviewerId))
            {
                throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Interviewer), entity.InterviewerId));
            }

            if (!_context.Сandidates.AsNoTracking().Any(i => i.Id == entity.CandidatId))
            {
                throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Candidate), entity.CandidatId));
            }

            var result = _context.Interviews.Add(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = _context.Interviews.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Interview), id));
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Interview> Get(int id)
        {
            var entity = await _context.Interviews
                .Include(i => i.Candidat)
                .Include(i => i.Interviewer)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (entity == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Interview), id));
            }
            return entity;
        }

        public async Task<IList<Interview>> GetAll()
        {
            return await _context.Interviews
                .Include(i => i.Candidat)
                .Include(i => i.Interviewer)
                .ToListAsync();
        }

        public async Task<IList<Interview>> GetForToday()
        {
            return await _context.Interviews
                .Include(i => i.Candidat)
                .Include(i => i.Interviewer)
                .Where(i => i.EndDate.Day == DateTime.UtcNow.Day 
                            && i.EndDate.Month == DateTime.UtcNow.Month
                            && i.EndDate.Year == DateTime.UtcNow.Year)
                .ToListAsync();
        }

        public async Task Update(Interview entity)
        {
            var entityToUpdate = _context.Interviews.FirstOrDefault(e => e.Id == entity.Id);
            if (entityToUpdate == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Interview), entity.Id));
            }
            mapper.Map(entity, entityToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}

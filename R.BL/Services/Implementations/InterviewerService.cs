using AutoMapper;
using Microsoft.EntityFrameworkCore;
using R.DAL.Contexts;
using R.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.BL.Services.Implementations
{
    public class InterviewerService : IInterviewerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public InterviewerService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<int> Create(Interviewer entity)
        {
            var result = _context.Interviewers.Add(entity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task Delete(int id)
        {
            var entity = _context.Interviewers.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Interviewer), id));
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Interviewer> Get(int id)
        {
            var entity = await _context.Interviewers.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Interviewer), id));
            }
            return entity;
        }

        public async Task<IList<Interviewer>> GetAll()
        {
            return await _context.Interviewers.ToListAsync();
        }

        public async Task Update(Interviewer entity)
        {
            var entityToUpdate = _context.Interviewers.FirstOrDefault(e => e.Id == entity.Id);
            if (entityToUpdate == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.BuildNotFoundMessage(nameof(Interviewer), entity.Id));
            }
            mapper.Map(entity, entityToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}

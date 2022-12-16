using R.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.BL.Services
{
    public interface IInterviewerService
    {
        public Task<IList<Interviewer>> GetAll();

        public Task<Interviewer> Get(int id);

        public Task Update(Interviewer entity);

        public Task Delete(int id);

        public Task<int> Create(Interviewer entity);
    }
}

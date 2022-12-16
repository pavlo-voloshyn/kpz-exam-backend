using R.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.BL.Services
{
    public interface IInterviewService
    {
        public Task<IList<Interview>> GetAll();

        public Task<IList<Interview>> GetForToday();

        public Task<Interview> Get(int id);

        public Task Update(Interview entity);

        public Task Delete(int id);

        public Task<int> Create(Interview entity);
    }
}

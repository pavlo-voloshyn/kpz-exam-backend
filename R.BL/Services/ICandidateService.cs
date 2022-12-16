using R.DAL.Models;

namespace R.BL.Services;

public interface ICandidateService
{
    public Task<IList<Candidate>> GetAll();

    public Task<Candidate> Get(int id);

    public Task Update(Candidate entity);

    public Task Delete(int id);

    public Task<int> Create(Candidate entity);
}

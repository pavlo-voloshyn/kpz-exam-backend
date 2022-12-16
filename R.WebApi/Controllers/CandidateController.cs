using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R.BL.Services;
using R.DAL.Models;
using R.WebApi.ViewModels;

namespace R.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IMapper _mapper;

        public CandidateController(ICandidateService candidateService, IMapper mapper)
        {
            _candidateService = candidateService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateInsert entityInsert)
        {
            var entity = _mapper.Map<Candidate>(entityInsert);
            return Ok(await _candidateService.Create(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CandidateUpdate entityUpdate)
        {
            var entity = _mapper.Map<Candidate>(entityUpdate);
            await _candidateService.Update(entity);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _candidateService.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _candidateService.Get(id);
            return Ok(_mapper.Map<CandidateView>(entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _candidateService.GetAll();
            return Ok(_mapper.Map<IList<CandidateView>>(entities));
        }
    }
}

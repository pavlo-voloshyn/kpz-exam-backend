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
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerService _interviewerService;
        private readonly IMapper _mapper;

        public InterviewerController(IInterviewerService interviewerService, IMapper mapper)
        {
            _interviewerService = interviewerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewerInsert entityInsert)
        {
            var entity = _mapper.Map<Interviewer>(entityInsert);
            return Ok(await _interviewerService.Create(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Update(InterviewerUpdate entityUpdate)
        {
            var entity = _mapper.Map<Interviewer>(entityUpdate);
            await _interviewerService.Update(entity);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _interviewerService.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _interviewerService.Get(id);
            return Ok(_mapper.Map<InterviewerView>(entity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _interviewerService.GetAll();
            return Ok(_mapper.Map<IList<InterviewerView>>(entities));
        }
    }
}

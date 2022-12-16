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
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        private readonly IMapper _mapper;

        public InterviewController(IInterviewService interviewService, IMapper mapper)
        {
            _interviewService = interviewService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewInsert entityInsert)
        {
            var entity = _mapper.Map<Interview>(entityInsert);
            return Ok(await _interviewService.Create(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Update(InterviewUpdate entityUpdate)
        {
            var entity = _mapper.Map<Interview>(entityUpdate);
            await _interviewService.Update(entity);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _interviewService.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _interviewService.Get(id);
            return Ok(_mapper.Map<InterviewView>(entity));
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetForToday()
        {
            var entities = await _interviewService.GetForToday();
            return Ok(_mapper.Map<IList<InterviewView>>(entities));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _interviewService.GetAll();
            return Ok(_mapper.Map<IList<InterviewView>>(entities));
        }
    }
}

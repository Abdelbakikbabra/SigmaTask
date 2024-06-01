using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.API.Models;
using TestTask.API.Services;
using TestTask.API.Services.Candidate;

namespace TestTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ILogger? _logger;
        public CandidatController(ICandidateService candidateService,ILogger<CandidatController>? logger = null)
        {
            _candidateService = candidateService;
            _logger = logger ;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = _candidateService.GetCandidats();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate([FromBody] SaveCandidateDTO saveCandidateDto)
        {
            try
            {
                _logger?.LogInformation("AddOrUpdate called");

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var candidate = await _candidateService.AddOrUpdateCandidate(saveCandidateDto);

                _logger?.LogInformation("AddOrUpdate completed");

                return Ok(candidate);
            }
            catch (Exception e)
            {
                _logger?.LogError("An error has occured:"+ e.Message);
                return BadRequest(ModelState);
            }
            
        }

    }
}

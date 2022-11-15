using JobCandidatesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidatesApi.Controllers
{
    [ApiController]
    [Route("candidate")]
    public class ApiController : ControllerBase
    {

        private readonly ICandidateRepository candidateRepository;

        public ApiController(ICandidateRepository candidateRepository)
        {
            this.candidateRepository = candidateRepository;
        }


        [HttpPost()]
        public IActionResult CreateOrUpdateCandidate(Candidate candidate)
        {
            try
            {
                if (candidate == null)
                {
                    return BadRequest();
                }

                candidateRepository.CreateOrUpdateCandidate(candidate);

                return Ok("Task completed succesfully");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Task Failed.");
            }

        }

    }
}

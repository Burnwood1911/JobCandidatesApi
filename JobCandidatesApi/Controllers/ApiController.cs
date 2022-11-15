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
        public IActionResult CreateOrUpdateCandidate(Candidate? candidate)
        {
            try
            {
               
                var cand = candidateRepository.CreateOrUpdateCandidate(candidate);

                if (cand != null) {
                    return Ok("Task completed succesfully");
                }else
                {
                    return BadRequest();
                }

                

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Task Failed.");
            }

        }

    }
}

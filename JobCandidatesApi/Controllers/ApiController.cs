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
        public IActionResult CreateCandidate(Candidate candidate)
        {

            try
            {
                if (candidate == null)
                {
                    return BadRequest();
                }

                var createdCandidate = candidateRepository.CreateCandidate(candidate);

                return CreatedAtAction("create", createdCandidate);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating candidate.");
            }


        }

        [HttpPut()]
        public IActionResult UpdateCandidate(Candidate candidate)
        {
            try
            {
                if (candidate == null)
                {
                    return BadRequest();
                }

                var updatedCandidate = candidateRepository.UpdateCandidate(candidate);

                return Ok(updatedCandidate);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating candidate.");
            }

        }


    }
}

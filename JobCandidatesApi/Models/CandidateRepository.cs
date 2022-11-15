using JobCandidatesApi.Services;
using System.Diagnostics;

namespace JobCandidatesApi.Models
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ICSVService _csvService;

        public CandidateRepository(ICSVService csvService)
        {
            _csvService = csvService;
        }


        public void CreateOrUpdateCandidate(Candidate candidate)
        {
            var email = candidate.Email;

            if(File.Exists(@"D:\file.csv"))
            {
                var candidates = _csvService.ReadCSV<Candidate>();

                var doesCandidateExist = candidates.Any(c => c.Email == email);

                if (doesCandidateExist)
                {
                    _csvService.UpdateCandidate(candidate);
                }
                else
                {
                    _csvService.CreateCandidate(candidate, false);
                }

            }else
            {
                _csvService.CreateCandidate(candidate, true);
            }

        }
       
    }
}

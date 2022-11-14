namespace JobCandidatesApi.Models
{
    public interface ICandidateRepository
    {
        Task<Candidate> CreateCandidate(Candidate candidate);
        Task<Candidate> UpdateCandidate(Candidate candidate);
    }

}

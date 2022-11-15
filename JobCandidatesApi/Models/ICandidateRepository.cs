namespace JobCandidatesApi.Models
{
    public interface ICandidateRepository
    {
        public Candidate? CreateOrUpdateCandidate(Candidate candidate);
    }

}

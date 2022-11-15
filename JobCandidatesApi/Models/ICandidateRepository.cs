namespace JobCandidatesApi.Models
{
    public interface ICandidateRepository
    {
        public void CreateOrUpdateCandidate(Candidate candidate);
    }

}

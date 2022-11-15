using JobCandidatesApi.Models;

namespace JobCandidatesApi.Services
{
    public interface ICSVService
    {
        public IEnumerable<T> ReadCSV<T>();
        public void CreateCandidate(Candidate record);

        public void UpdateCandidate(Candidate record);

    }
}

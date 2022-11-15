using JobCandidatesApi.Models;

namespace JobCandidatesApi.Services
{
    public interface ICSVService
    {
        public IEnumerable<T> ReadCSV<T>();
        public void CreateCandidate(Candidate record, bool newAddition);

        public void UpdateCandidate(Candidate record);

    }
}

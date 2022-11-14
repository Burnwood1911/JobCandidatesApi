namespace JobCandidatesApi.Models
{
    public class Candidate
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string? PhoneNumber { get; }
        public string Email { get; }

        public string? CallTime { get; }
        public string? LinkedIn { get; }
        public string? Github { get; }
        public string Comment { get; }

        public Candidate(string firstName, string lastName, string? phoneNumber, string email, string? callTime, string? linkedIn, string? github, string comment)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            CallTime = callTime;
            LinkedIn = linkedIn;
            Github = github;
            Comment = comment;
        }
    }
}

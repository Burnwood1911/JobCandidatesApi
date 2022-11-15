using System;
using Xunit;
using Moq;
using JobCandidatesApi.Models;
using JobCandidatesApi.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace JobCandidatesApi.Tests
{
    public class ApiControllerTests
    {
        [Fact]
        public void CreateOrUpdateCandidate_WithUnexistingCandidate_ReturnsBadRequest()
        {
            var repositoryStub = new Mock<ICandidateRepository>();
            repositoryStub.Setup(repo => repo.CreateOrUpdateCandidate(It.IsAny<Candidate>())).Returns((Candidate)null);

            var controller = new ApiController(repositoryStub.Object);

            var result = controller.CreateOrUpdateCandidate(null);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}

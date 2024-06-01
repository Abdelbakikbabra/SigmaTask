using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.API.Models;
using TestTask.API.Services.Candidate;
using TestTask.API.Services;
using TestTask.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Tests.Controllers
{
    public class CandidatesControllerTests
    {
        [Fact]
        public async Task AddOrUpdateCandidate_ReturnsOkResult_WhenValid()
        {
            // Arrange
            var candidateDto = new SaveCandidateDTO
            {
                FirstName = "Abdelbaki",
                LastName = "Kbabra",
                Email = "kbabra.abdelbaki@gmail.com",
                Comment = "Great candidate"
            };

            var candidate = new Candidat
            {
                FirstName = "Abdelbaki",
                LastName = "Kbabra",
                Email = "kbabra.abdelbaki@gmail.com",
                Comment = "Great candidate"
            };

            var mockService = new Mock<ICandidateService>();
            mockService.Setup(service => service.AddOrUpdateCandidate(candidateDto))
                .ReturnsAsync(candidate);

            var controller = new CandidatController(mockService.Object);

            // Act
            var result = await controller.AddOrUpdate(candidateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCandidate = Assert.IsType<Candidat>(okResult.Value);
            Assert.Equal(candidate.Email, returnedCandidate.Email);
        }

        [Fact]
        public async Task AddOrUpdateCandidate_ReturnsBadRequest_WhenInvalid()
        {
            // Arrange
            var candidateDto = new SaveCandidateDTO
            {
                FirstName = "Abdelbaki",
                LastName = "Kbabra",
                //Email = "kbabra.abdelbaki@gmail.com",
                Email = null,
                Comment = "Great candidate"
            };

            var mockService = new Mock<ICandidateService>();
            var controller = new CandidatController(mockService.Object);
            controller.ModelState.AddModelError("Email", "Required");

            // Act
            var result = await controller.AddOrUpdate(candidateDto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

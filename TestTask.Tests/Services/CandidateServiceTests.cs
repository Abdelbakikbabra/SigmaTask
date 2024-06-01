using Microsoft.EntityFrameworkCore;
using TestTask.API.Models;
using TestTask.API.Services;
using TestTask.API.Services.Candidate;

namespace TestTask.Tests.Services
{
    public class CandidateServiceTests
    {
        private readonly CandidatContext _context;
        private readonly ICandidateService _candidateService;

        public CandidateServiceTests()
        {
            var options = new DbContextOptionsBuilder<CandidatContext>()
                .UseInMemoryDatabase(databaseName: "TeskTask")
                .Options;

            _context = new CandidatContext(options);
            _candidateService = new CandidatService(_context);
        }

        [Fact]
        public async Task AddOrUpdateCandidate_AddsNewCandidate()
        {
            // Arrange
            var candidateDto = new SaveCandidateDTO
            {
                FirstName = "Abdelbaki",
                LastName = "Kbabra",
                Email = "Abdelbaki.Kbabra@gmail.com",
                Comment = "New candidate"
            };

            // Act
            var result = await _candidateService.AddOrUpdateCandidate(candidateDto);

            // Assert
            var candidateInDb = _context.Candidats.SingleOrDefault(c => c.Email == candidateDto.Email);
            Assert.NotNull(candidateInDb);
            Assert.Equal(candidateDto.FirstName, candidateInDb.FirstName);
        }

        [Fact]
        public async Task AddOrUpdateCandidate_UpdatesExistingCandidate()
        {
            // Arrange
            var existingCandidate = new Candidat
            {
                FirstName = "Abdelbaki",
                LastName = "Kbabra",
                Email = "Abdelbaki.Kbabra@gmail.com",
                Comment = "Existing candidate"
            };
            _context.Candidats.Add(existingCandidate);
            await _context.SaveChangesAsync();

            var candidateDto = new SaveCandidateDTO
            {
                FirstName = "Abdelbaki",
                LastName = "Kbabra",
                Email = "Abdelbaki.Kbabra@gmail.com",
                Comment = "Updated candidate"
            };

            // Act
            var result = await _candidateService.AddOrUpdateCandidate(candidateDto);

            // Assert
            var candidateInDb = _context.Candidats.SingleOrDefault(c => c.Email == candidateDto.Email);
            Assert.NotNull(candidateInDb);
            Assert.Equal(candidateDto.FirstName, candidateInDb.FirstName);
        }
    }
}
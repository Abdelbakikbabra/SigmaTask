using TestTask.API.Models;

namespace TestTask.API.Services.Candidate
{
    public interface ICandidateService
    {
        /// <summary>
        /// Get all candidats
        /// </summary>
        /// <returns>A list of candidats</returns>
        public List<Candidat> GetCandidats();
        /// <summary>
        /// Add or update a candidate
        /// </summary>
        /// <param name="saveCandidateDto"></param>
        /// <returns>Return the candidate</returns>
        public Task<Candidat> AddOrUpdateCandidate(SaveCandidateDTO saveCandidateDto);
    }
}

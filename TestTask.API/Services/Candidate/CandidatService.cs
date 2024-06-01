using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TestTask.API.Models;

namespace TestTask.API.Services.Candidate
{
    public class CandidatService : ICandidateService
    {
        private readonly CandidatContext _context;
        public CandidatService(CandidatContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all the candidatsd
        /// </summary>
        /// <returns>A list of candidats</returns>
        public List<Candidat> GetCandidats()
        {
            var data = _context.Candidats.ToList();
            return data;
        }
        /// <summary>
        /// /Add or update a candidate
        /// </summary>
        /// <param name="saveCandidateDto"></param>
        /// <returns>return candidate</returns>
        public async Task<Candidat> AddOrUpdateCandidate(SaveCandidateDTO saveCandidateDto)
        {
            Candidat? candidate = _context.Candidats.SingleOrDefault(c => c.Email == saveCandidateDto.Email);

            if (candidate == null)
            {
                candidate = new Candidat
                {
                    FirstName = saveCandidateDto.FirstName,
                    LastName = saveCandidateDto.LastName,
                    PhoneNumber = saveCandidateDto.PhoneNumber,
                    Email = saveCandidateDto.Email,
                    BestCallStartTime = saveCandidateDto.BestCallStartTime,
                    BestCallEndTime = saveCandidateDto.BestCallEndTime,
                    LinkedinUrl = saveCandidateDto.LinkedinUrl,
                    GithubUrl = saveCandidateDto.GithubUrl,
                    Comment = saveCandidateDto.Comment
                };

                _context.Candidats.Add(candidate);
            }
            else
            {

                candidate.PhoneNumber = saveCandidateDto.PhoneNumber;
                candidate.LastName = saveCandidateDto.LastName;
                candidate.FirstName = saveCandidateDto.FirstName;
                candidate.BestCallEndTime = saveCandidateDto.BestCallEndTime;
                candidate.BestCallStartTime = saveCandidateDto.BestCallStartTime;
                candidate.LinkedinUrl = saveCandidateDto.LinkedinUrl;
                candidate.GithubUrl = saveCandidateDto.GithubUrl;
                candidate.Comment = saveCandidateDto.Comment;
            }

            await _context.SaveChangesAsync();
            return candidate;

        }

        
    }
}

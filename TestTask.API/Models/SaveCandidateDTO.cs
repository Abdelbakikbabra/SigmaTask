using System.ComponentModel.DataAnnotations;

namespace TestTask.API.Models
{
    public class SaveCandidateDTO
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime? BestCallStartTime { get; set; }
        public DateTime? BestCallEndTime { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? GithubUrl { get; set; }
        [Required]
        public string? Comment { get; set; }
    }
}

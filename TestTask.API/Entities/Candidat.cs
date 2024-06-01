using System.ComponentModel.DataAnnotations;

namespace TestTask.API.Models
{
    public class Candidat
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName {  get; set; }
        [Required]
        public string? LastName {  get; set; }
        public string? PhoneNumber {  get; set; }
        [Required]
        public string? Email {  get; set; }
        public DateTime? BestCallStartTime { get; set; }
        public DateTime? BestCallEndTime { get; set; }
        public string? LinkedinUrl {  get; set; }
        public string? GithubUrl {  get; set; }
        [Required]
        public string? Comment {  get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace R.WebApi.ViewModels
{
    public class InterviewUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int CandidatId { get; set; }

        [Required]
        public int InterviewerId { get; set; }
    }
}

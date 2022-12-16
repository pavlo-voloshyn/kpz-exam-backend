using System.ComponentModel.DataAnnotations;

namespace R.WebApi.ViewModels
{
    public class InterviewInsert
    {
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

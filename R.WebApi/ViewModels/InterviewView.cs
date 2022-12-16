namespace R.WebApi.ViewModels
{
    public class InterviewView
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public CandidateView Candidat { get; set; }

        public InterviewerView Interviewer { get; set; }
    }
}

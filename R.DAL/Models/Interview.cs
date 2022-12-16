using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.DAL.Models
{
    public class Interview : EntityBase
    {

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int CandidatId { get; set; }

        public int InterviewerId { get; set; }


        public Candidate Candidat { get; set; }

        public Interviewer Interviewer { get; set; }
    }
}

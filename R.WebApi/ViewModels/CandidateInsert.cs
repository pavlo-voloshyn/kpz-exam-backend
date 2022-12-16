using System.ComponentModel.DataAnnotations;

namespace R.WebApi.ViewModels
{
    public class CandidateInsert
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Stack { get; set; }

        [Required]
        public string Level { get; set; }
    }
}

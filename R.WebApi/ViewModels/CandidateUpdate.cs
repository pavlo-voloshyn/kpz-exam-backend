using System.ComponentModel.DataAnnotations;

namespace R.WebApi.ViewModels
{
    public class CandidateUpdate
    {
        [Required]
        public int Id { get; set; }

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

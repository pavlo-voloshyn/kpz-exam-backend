using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R.DAL.Models
{
    public class Interviewer : EntityBase
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

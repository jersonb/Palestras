using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TechWeekFatecSul.Models
{
    [Table("TB_EXAMPLE")]
    public class Example
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Matrícula")]

        public string Registration { get; set; }
        [Display(Name = "Presente")]
        public bool Attended { get; set; }
    }
}

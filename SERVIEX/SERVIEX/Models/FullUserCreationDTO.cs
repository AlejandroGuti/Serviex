using SERVIEX.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SERVIEX.Models
{
    public class FullUserCreationDTO
    {
        [MaxLength(100)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Born Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BornDate { get; set; }

        public int genderid { get; set; }

    }
}

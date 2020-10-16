using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SERVIEX.Entities
{
    public class User
    {
        public int id { get; set; }
        [MaxLength(100)]
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Born Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BornDate { get; set; }

        public Gender gender { get; set; }

        public string GenderText => gender != null && !string.IsNullOrEmpty(gender.Type) ? gender.Type : "Not defined" ;

    }
}

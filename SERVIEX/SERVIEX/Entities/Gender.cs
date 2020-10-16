using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SERVIEX.Entities
{
    public class Gender
    {
        public int id { get; set; }

        [MaxLength(1)]
        [Display(Name = "Gender")]
        public string Type { get; set; }

        public ICollection<User> users { get; set; }
    }
}

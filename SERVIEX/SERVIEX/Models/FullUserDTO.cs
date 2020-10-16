using SERVIEX.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SERVIEX.Models
{
    public class FullUserDTO : User
    {
        public int genderid { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using SERVIEX.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SERVIEX.Models
{
    public class UserViewModel : User
    {
        public IEnumerable<SelectListItem> Genders { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You must choose a Gender.")]
        public int GenderId { get; set; }


    }
}
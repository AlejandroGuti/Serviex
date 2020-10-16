using Microsoft.AspNetCore.Mvc.Rendering;
using SERVIEX.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SERVIEX.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly ApplicationDbContext _context;

        public CombosHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetComboGenders()
        {
            var list = _context.genders.Select(p => new SelectListItem
            {
                Text = p.Type,
                Value = $"{p.id}",
            })
                .OrderBy(p => p.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Select a gender",
                Value = "0",
            });

            return list;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SERVIEX.Entities;
using SERVIEX.Models;

namespace SERVIEX.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {

        }
        public DbSet <Gender> genders { get; set; }
        public DbSet<User> users { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechWeekFatecSul.Models;

namespace TechWeekFatecSul.Data
{
    public class TechWeekFatecSulContext : DbContext
    {
        public TechWeekFatecSulContext (DbContextOptions<TechWeekFatecSulContext> options)
            : base(options)
        {
        }

        public DbSet<TechWeekFatecSul.Models.Example> Example { get; set; }
    }
}

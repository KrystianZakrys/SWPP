using Microsoft.EntityFrameworkCore;
using SWPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPP.Infrastructure
{
    public class SWPPContext : DbContext
    {
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<SearchHistory> SearchHistories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public SWPPContext(DbContextOptions<SWPPContext> options)
            : base(options)
        {
        }
    }
}

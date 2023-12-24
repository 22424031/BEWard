using Microsoft.EntityFrameworkCore;
using Ward.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Domain;

namespace Ward.Persistent
{
    public class WardMapContext : AuditTableDbContext
    {
        public WardMapContext(DbContextOptions<WardMapContext> options) : base(options)
        {
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WardMapContext).Assembly);
        }
        public DbSet<Ads> Ads { get; set; }

    }
}

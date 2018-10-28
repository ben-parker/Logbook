using Logbook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Services
{
    public class LogbookDBContext : DbContext
    {
        public LogbookDBContext(DbContextOptions<LogbookDBContext> options)
            : base(options)
        {

        }

        public DbSet<Tracked> Tracked { get; set; }
        public DbSet<Done> Done { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracked>().OwnsOne(
                t => t.Recurrence,
                r => r.Property(p => p.RecurString).HasColumnName("RecurString")                    
             );

            modelBuilder.Entity<Recurrence>().Ignore(i => i.Count);
            modelBuilder.Entity<Recurrence>().Ignore(i => i.DaysOfWeek);
            modelBuilder.Entity<Recurrence>().Ignore(i => i.Frequency);
            modelBuilder.Entity<Recurrence>().Ignore(i => i.Interval);
            modelBuilder.Entity<Recurrence>().Ignore(i => i.Month);
            modelBuilder.Entity<Recurrence>().Ignore(i => i.MonthDay);
        }
    }
}
